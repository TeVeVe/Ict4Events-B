using System;

namespace SharedClasses.Data
{
    public class Database
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { protected get; set; }
        public string Service { get; set; }
        public int Port { get; set; }

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Host) || string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Service))
                    throw new FormatException("ConnectionString could not be build. Missing information.");
                return "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = " + Host + ")(PORT = " + Port +
                       "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = " + Service + ")));Password=" + Password +
                       ";User ID=" + Username;
            }
        }

        public Database(string username, string password, string host, string service)
        {
            Username = username;
            Password = password;
            Host = host;
            Port = 1521;
            Service = service;
        }

        public Database(string username, string password, string host, int port, string service)
        {
            Username = username;
            Password = password;
            Host = host;
            Port = port;
            Service = service;
        }
    }
}