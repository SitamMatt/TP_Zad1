using System;
using System.Runtime.Serialization;

namespace Model
{
    [Serializable]
    internal class UnknownEventException : Exception
    {
        public UnknownEventException()
        {
        }

        public UnknownEventException(string message) : base(message)
        {
        }

        public UnknownEventException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownEventException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}