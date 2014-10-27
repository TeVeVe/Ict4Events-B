using System;

namespace SharedClasses.Exceptions
{
    public class NoActiveControllerException : Exception
    {
        public NoActiveControllerException(string value) : base(string.Format("No controller found with the name '{0}'", value))
        {
            
        }

        public NoActiveControllerException() : base("No active controller has been set.")
        {
        }
    }
}