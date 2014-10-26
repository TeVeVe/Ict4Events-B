﻿using System;
using SharedClasses.Models;

namespace SharedClasses.Events
{
    public class MessageEventArgs : EventArgs
    {
        public string Message { get; set; }

        public MessageEventArgs(string message)
        {
            Message = message;
        }
    }
}