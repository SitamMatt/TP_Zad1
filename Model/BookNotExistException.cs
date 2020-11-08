using System;
using System.Runtime.Serialization;

namespace Model
{
    [Serializable]
    public class BookNotExistException : Exception
    {
        public BookNotExistException()
        {
        }

        public BookNotExistException(string message) : base(message)
        {
        }

        public BookNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BookNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}