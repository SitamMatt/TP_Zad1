using System;
using System.Runtime.Serialization;

namespace Model.Exceptions
{
    [Serializable]
    public class BookCheckedOutException : Exception
    {
        public BookCheckedOutException()
        {
        }

        public BookCheckedOutException(string message) : base(message)
        {
        }

        public BookCheckedOutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BookCheckedOutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}