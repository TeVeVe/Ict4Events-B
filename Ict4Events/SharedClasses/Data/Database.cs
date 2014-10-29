using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using SharedClasses.Data.AbstractClasses;
using SharedClasses.Data.Attributes;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;

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
        }

        public Database(string username, string password, string host, int port, string service)
        {
            Username = username;
            Password = password;
            Host = host;
            Port = port;
            Service = service;
        }

        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { protected get; set; }
        public string Service { get; set; }
        public int Port { get; set; }

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

        public void Dispose()
        {
        }

        public IEnumerable<T> Select<T>() where T : DataModel, new()
        {
            // Alle properties ophalen die public zijn van het Type IDataModel dat meegegeven is.
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public).Except(
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(prop => prop.GetCustomAttributes<DbIgnoreAttribute>(true).Any())).ToArray();

            // Key attribute property ophalen.
            TableAttribute tableName = typeof(T).GetCustomAttributes<TableAttribute>(true).FirstOrDefault();
            

            return Enumerable.Empty<T>();
        }
    }
}