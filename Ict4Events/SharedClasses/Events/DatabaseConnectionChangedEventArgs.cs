using System;
using System.Data;

namespace SharedClasses.Events
{
    public class DatabaseConnectionChangedEventArgs : EventArgs
    {
        public ConnectionState State { get; set; }

        public DatabaseConnectionChangedEventArgs(ConnectionState state)
        {
            State = state;
        }
    }
}