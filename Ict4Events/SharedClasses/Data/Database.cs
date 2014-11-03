using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using SharedClasses.Properties;

namespace SharedClasses.Data
{
    public class Database : IDisposable
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { protected get; set; }
        public string Service { get; set; }
        public int Port { get; set; }
        public string SID { get; set; }
        public OracleConnection Connection { get; protected set; }

        /// <summary>
        ///     ConnectionString used for connecting to the database. This property generates a new <see cref="ConnectionString" />
        ///     from the parameters.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(SID))
                {
                    return
                        string.Format(
                            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SID={2})));User ID={3};Password={4}",
                            Host, Port, SID, Username, Password);
                }
                return
                    string.Format(
                        "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SERVIE_NAME={2})));User ID={3};Password={4}",
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

        public static Database ConnectToService(string username, string password, string host, string service)
        {
            var db = new Database();

            db.Username = username;
            db.Password = password;
            db.Host = host;
            db.Port = 1521;
            db.Service = service;

            db.Open();

            return db;
        }

        public static Database ConnectToSid(string username, string password, string host, string sid)
        {
            var db = new Database();

            db.Username = username;
            db.Password = password;
            db.Host = host;
            db.Port = 1521;
            db.SID = sid;

            db.Open();

            return db;
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