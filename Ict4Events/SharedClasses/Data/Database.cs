using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace SharedClasses.Data
{
    public class Database : IDisposable
    {
        public Database(string username, string password, string host, string service)
        {
            Username = username;
            Password = password;
            Host = host;
            Port = 1521;
            Service = service;

            Open();
        }

        public Database(string username, string password, string host, int port, string service)
        {
            Username = username;
            Password = password;
            Host = host;
            Service = service;
            Port = port;

            Open();
        }

        /// <summary>
        /// Creates a new database instance with <see cref="ConnectionString"/> from the settings file.
        /// </summary>
        /// <returns></returns>
        public static Database FromSettings()
        {
            return new Database((string)Properties.Settings.Default["DB_UserID"], (string)Properties.Settings.Default["DB_Password"],
                (string)Properties.Settings.Default["DB_Server"], (string)Properties.Settings.Default["DB_Service"]);
        }

        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { protected get; set; }
        public string Service { get; set; }
        public int Port { get; set; }
        public OracleConnection Connection { get; protected set; }

        /// <summary>
        ///     ConnectionString used for connecting to the database. This property generates a new <see cref="ConnectionString" />
        ///     from the parameters.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Host) || string.IsNullOrWhiteSpace(Username) ||
                    string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Service))
                    throw new FormatException("ConnectionString could not be build. Missing information.");
                return "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = " + Host + ")(PORT = " + Port +
                       "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = " + Service + ")));Password=" + Password +
                       ";User ID=" + Username;
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
        ///     Opens the connection with the database with the parameters in the <see cref="ConnectionString" />.
        /// </summary>
        protected void Open()
        {
            if (Connection != null && Connection.State == ConnectionState.Open) return;

            Connection = new OracleConnection(ConnectionString);
            Connection.Open();
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
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var objs = new object[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                        objs[i] = reader[i];
                    yield return objs;
                }
            }
        }
    }
}