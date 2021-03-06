using System;
using System.Runtime.Serialization;

namespace Model.Exceptions
{
    [Serializable]
    public class BookNotCheckedOutException : Exception
    {
        public BookNotCheckedOutException()
        {
        }

        public BookNotCheckedOutException(string message) : base(message)
        {
        }

        public BookNotCheckedOutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BookNotCheckedOutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}