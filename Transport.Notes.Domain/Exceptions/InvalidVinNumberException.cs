using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Transport.Notes.Domain.Exceptions
{
    public class InvalidVinNumberException : Exception
    {
        public string VIN { get; set; }
        public InvalidVinNumberException(string vin)
        {
            VIN = vin;
        }

        public InvalidVinNumberException(string message, string vin) : base(message)
        {
            VIN = vin;
        }

        public InvalidVinNumberException(string message, Exception innerException, string vin) : base(message, innerException)
        {
            VIN = vin;
        }
    }
}
