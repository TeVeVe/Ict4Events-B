using System;
using System.Windows.Forms;

namespace SharedClasses.Events
{
    public delegate void AuthenticateEventHandler(object sender, AuthenticateEventArgs e);

    public class AuthenticateEventArgs : EventArgs
    {
        /// <summary>
        ///     Supported authentication methods.
        /// </summary>
        public enum AuthenticationMethod
        {
            RFIDNumber,
            Account
        }

        public AuthenticateEventArgs(string rfidNumber)
        {
            AuthMethod = AuthenticationMethod.RFIDNumber;
            RFIDNumber = rfidNumber;
        }

        public AuthenticateEventArgs(string username, string password)
        {
            AuthMethod = AuthenticationMethod.Account;
            Username = username;
            Password = password;
        }

        /// <summary>
        ///     Authentication method used.
        /// </summary>
        public AuthenticationMethod AuthMethod { get; protected set; }

        /// <summary>
        ///     RFID entered in the <see cref="TextBox" />.
        /// </summary>
        public string RFIDNumber { get; protected set; }

        /// <summary>
        ///     Username entered in the <see cref="TextBox" />.
        /// </summary>
        public string Username { get; protected set; }

        /// <summary>
        ///     Password entered in the <see cref="TextBox" />.
        /// </summary>
        public string Password { get; protected set; }

        /// <summary>
        ///     Determines if the user has been authorized. Can be changed by event subscribers.
        /// </summary>
        public bool Authorized { get; set; }
    }
}