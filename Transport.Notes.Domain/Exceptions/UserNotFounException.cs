using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.Domain.Expections
{
    public class UserNotFounException : Exception
    {
        private string Username {get;set;}
        public UserNotFounException(string username)
        {
            Username = username;
        }

        public UserNotFounException(string message,string username) : base(message)
        {
            Username = username;
        }

        public UserNotFounException(string message, Exception innerException,string username) : base(message, innerException)
        {
            Username = username;
        }

    }
}
