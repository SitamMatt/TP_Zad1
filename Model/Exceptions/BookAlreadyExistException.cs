using System;
using System.Runtime.Serialization;

namespace Model.Exceptions
{
    [Serializable]
    public class BookAlreadyExistException : Exception
    {
        public BookAlreadyExistException()
        {
        }

        public BookAlreadyExistException(string message) : base(message)
        {
        }

        public BookAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BookAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}