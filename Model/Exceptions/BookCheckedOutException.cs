using System;
using System.Runtime.Serialization;

namespace Model
{
    [Serializable]
    internal class BookCheckedOutException : Exception
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