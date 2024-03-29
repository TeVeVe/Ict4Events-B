﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Oracle.DataAccess.Client;
using SharedClasses.Events;
using SharedClasses.Extensions;
using SharedClasses.Properties;

namespace SharedClasses.Data
{
    public class Database : IDisposable
    {
        private OracleConnection _connection;
        public int QueryTimeout { get; set; }

        /// <summary>
        ///     Hostname or IP to connect to the database.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        ///     Login username to connect to the database.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     Login password to connect to the database.
        /// </summary>
        public string Password { protected get; set; }

        /// <summary>
        ///     Service name of the connection. Leave empty for <see cref="SID" />.
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        ///     Port to connect to the database.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        ///     SID of the connection. Leave empty for <see cref="Service" />.
        /// </summary>
        public string SID { get; set; }

        /// <summary>
        ///     Connection which holds the session to the database.
        /// </summary>
        public OracleConnection Connection
        {
            get { return _connection; }
            protected set
            {
                if (_connection != null)
                    _connection.Dispose();
                _connection = value;
                _connection.StateChange +=
                    (sender, args) =>
                        OnConnectionStateChanged(new DatabaseConnectionChangedEventArgs(_connection.State));
            }
        }

        /// <summary>
        ///     ConnectionString used for connecting to the database. This property generates a new <see cref="ConnectionString" />
        ///     from the parameters.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                if (File.Exists("connection.txt"))
                    return File.ReadAllText("connection.txt");

                if (!string.IsNullOrWhiteSpace(SID))
                {
                    return
                        string.Format(
                            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SID={2})));User ID={3};Password={4}",
                            Host, Port, SID, Username, Password);
                }
                return
                    string.Format(
                        "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User ID={3};Password={4}",
                        Host, Port, Service, Username, Password);
            }
        }

        /// <summary>
        ///     Closes the connection with the database and releases the resources.
        /// </summary>
        public void Dispose()
        {
            Close();
        }

        /// <summary>
        ///     Activate a new database connection.
        /// </summary>
        /// <param name="username">Login username to access the database.</param>
        /// <param name="password">Login password to access the database.</param>
        /// <param name="host">Hostname or IP to connect to the database.</param>
        /// <param name="service">Service name of the connection.</param>
        /// <returns></returns>
        public static Database ConnectToService(string username, string password, string host, string service)
        {
            var db = new Database();

            db.Username = username;
            db.Password = password;
            db.Host = host;
            db.Port = 1521;
            db.Service = service;
            db.QueryTimeout = int.Parse((string)Settings.Default["DB_QueryTimeout"]);

            try
            {
                db.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Er kon geen verbinding worden gemaakt met de database.", "Database verbinding fout",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(-1);
            }

            return db;
        }

        /// <summary>
        ///     Activate a new database connection.
        /// </summary>
        /// <param name="username">Login username to access the database.</param>
        /// <param name="password">Login password to access the database.</param>
        /// <param name="host">Hostname or IP to connect to the database.</param>
        /// <param name="sid">SID name of the connection.</param>
        /// <returns></returns>
        public static Database ConnectToSid(string username, string password, string host, string sid)
        {
            var db = new Database();

            db.Username = username;
            db.Password = password;
            db.Host = host;
            db.Port = 1521;
            db.SID = sid;
            db.QueryTimeout = int.Parse((string)Settings.Default["DB_QueryTimeout"]);

            try
            {
                db.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Er kon geen verbinding worden gemaakt met de database.", "Database verbinding fout",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(-1);
            }

            return db;
        }

        public event EventHandler<DatabaseConnectionChangedEventArgs> ConnectionStateChanged;

        protected virtual void OnConnectionStateChanged(DatabaseConnectionChangedEventArgs e)
        {
            EventHandler<DatabaseConnectionChangedEventArgs> handler = ConnectionStateChanged;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Creates a new database instance with <see cref="ConnectionString" /> from the settings file.
        /// </summary>
        /// <returns></returns>
        public static Database FromSettings()
        {
            return ConnectToService((string)Settings.Default["DB_UserID"], (string)Settings.Default["DB_Password"],
                (string)Settings.Default["DB_Server"], (string)Settings.Default["DB_Service"]);
        }

        /// <summary>
        ///     Opens the connection with the database with the parameters in the <see cref="ConnectionString" />.
        /// </summary>
        protected void Open()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                return;

            Connection = new OracleConnection(ConnectionString);
            Task openTask = null;
            try
            {
                openTask = Task.Factory.StartNew(() => Connection.Open(), TaskCreationOptions.LongRunning);
            }

            catch (TypeInitializationException ex)
            {
                MessageBox.Show(String.Format("Geen connectie met de database \r\nDetails:{0}", ex.Message));
            }

            catch (OracleException ex)
            {
                Debug.WriteLine(ex.Message);
                Environment.Exit(-1);
            }

            openTask.Wait(QueryTimeout);

            if (!openTask.IsCompleted)
                throw new TimeoutException("Could not find and connect database.");
        }

        /// <summary>
        ///     Closes the connection with the database and releases the resources.
        /// </summary>
        protected void Close()
        {
            Connection.Dispose();
        }

        /// <summary>
        ///     Executes the query on the connected database and returns the results.
        /// </summary>
        /// <param name="command">SQL command to send to the database.</param>
        /// <returns>A collection of the rows returned by the database.</returns>
        public IEnumerable<object[]> Query(string command)
        {
            using (var cmd = new OracleCommand(command, Connection))
            using (Task<OracleDataReader> readTask = Task.Factory.StartNew(() => cmd.ExecuteReader()))
            {
                // Wait for the database to return the DataReader.
                readTask.Wait(QueryTimeout);

                if (!readTask.IsCompleted)
                    throw new TimeoutException("Database reader was not recieved from the database.");

                // Get the reader from the database.
                OracleDataReader reader = readTask.Result;

                // Activate the objects from the rows and return them as a collection.
                while (reader.Read())
                {
                    var objs = new object[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                        objs[i] = reader[i];
                    yield return objs;
                }
            }
        }

        public DataTable ExecuteCursorProcedure(string procedureName, params KeyValuePair<string, object>[] parms)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
                throw new ArgumentException("ProcedureName must not be empty.", "procedureName");

            using (var da = new OracleDataAdapter())
            using (var cmd = new OracleCommand())
            {
                cmd.Connection = Connection;
                cmd.CommandText = procedureName;
                cmd.CommandType = CommandType.StoredProcedure;

                // Add default OUT cursor.
                cmd.Parameters.Add("P_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                // Add stored procedure parameters.
                foreach (var parm in parms)
                    cmd.Parameters.Add(parm.Key, parm.Value.GetOrableDbType()).Value = parm.Value;

                da.SelectCommand = cmd;
                var table = new DataTable();
                da.Fill(table);

                return table;
            }
        }

        /// <summary>
        ///     Executes a query on the database and returns the records affected.
        /// </summary>
        /// <param name="command">SQL command to send to the database.</param>
        /// <returns>Number of records that were affected by the SQL query.</returns>
        public int ExecuteNonQuery(string command)
        {
            using (var cmd = new OracleCommand(command, Connection))
            {
                // Wait for database to return query results.
                Task<int> task = Task.Factory.StartNew(() => cmd.ExecuteNonQuery());
                task.Wait(QueryTimeout);

                if (!task.IsCompleted)
                    throw new TimeoutException("No response from database received.");

                return task.Result;
            }
        }

        /// <summary>
        ///     Executes a query on the database and returns the records affected.
        /// </summary>
        /// <param name="command"><see cref="StringBuilder" /> containing the SQL command to send to the database.</param>
        /// <returns>Number of records that were affected by the SQL query.</returns>
        public int ExecuteNonQuery(StringBuilder command)
        {
            return ExecuteNonQuery(command.ToString());
        }
    }
}