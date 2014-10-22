using System;
using SharedClasses.Models;

namespace SharedClasses.Events
{
    public delegate void MessageEventHandler(object sender, MessageEventArgs e);
    public class MessageEventArgs : EventArgs
    {
        public string Message { get; set; }

        public MessageEventArgs(string message)
        {
            Message = message;
        }
    }
}