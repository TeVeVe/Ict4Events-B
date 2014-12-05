using System;
using System.Data;

namespace SharedClasses.Events
{
    public class DatabaseConnectionChangedEventArgs : EventArgs
    {
        public DatabaseConnectionChangedEventArgs(ConnectionState state)
        {
            State = state;
        }

        public ConnectionState State { get; set; }
    }
}