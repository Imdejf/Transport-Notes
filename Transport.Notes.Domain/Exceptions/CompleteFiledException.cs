using System;

namespace Transport.Notes.Domain.Exceptions
{
    public class CompleteFiledException : Exception
    {
        public string FiledLenght { get; set; }
        public CompleteFiledException(string filedLenght)
        {
            FiledLenght = filedLenght;
        }

        public CompleteFiledException(string message, string filedLenght) : base(message)
        {
            FiledLenght = filedLenght;
        }

        public CompleteFiledException(string message, string filedLenght, Exception innerException) : base(message, innerException)
        {
            FiledLenght = filedLenght;
        }
    }
}
