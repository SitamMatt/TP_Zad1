using System;
using System.Runtime.Serialization;

namespace Model.Exceptions
{
    [Serializable]
    public  class InvalidModelException : Exception
    {
        public InvalidModelException()
        {
        }

        public InvalidModelException(string message) : base(message)
        {
        }

        public InvalidModelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidModelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}