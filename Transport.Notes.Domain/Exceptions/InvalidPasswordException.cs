using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.Domain.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        private string Username { get; set; }
        private string Password { get; set; }

        public InvalidPasswordException(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public InvalidPasswordException(string message, string username, string password) : base(message)
        {
            Username = username;
            Password = password;
        }

        public InvalidPasswordException(string message, Exception innerException, string username, string password) : base(message, innerException)
        {
            Username = username;
            Password = password;
        }

    }
}
