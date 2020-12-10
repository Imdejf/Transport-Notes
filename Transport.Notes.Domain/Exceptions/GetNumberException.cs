using System;

namespace Transport.Notes.Domain.Exceptions
{
    public class GetNumberException : Exception
    {
        public int Number { get; set; }
        public GetNumberException(int number)
        {
            Number = number;
        }

        public GetNumberException(string message, int number) : base(message)
        {
            Number = number;
        }

        public GetNumberException(string message, int number, Exception innerException) : base(message, innerException)
        {
            Number = number;
        }
    }
}
