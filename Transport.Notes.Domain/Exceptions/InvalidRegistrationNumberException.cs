using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Transport.Notes.Domain.Exceptions
{
    public class InvalidRegistrationNumberException : Exception
    {
        public string RegistrationNumber {get;set;}
        public InvalidRegistrationNumberException(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
        }

        public InvalidRegistrationNumberException(string message, string registrationNumber) : base(message)
        {
            RegistrationNumber = registrationNumber;
        }

        public InvalidRegistrationNumberException(string message, string registrationNumber, Exception innerException) : base(message, innerException)
        {
            RegistrationNumber = registrationNumber;
        }
    }
}
