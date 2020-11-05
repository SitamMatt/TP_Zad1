using System;
using System.Runtime.Serialization;

namespace Model
{
    [Serializable]
    internal class DuplicatedItemException : Exception
    {
        public DuplicatedItemException()
        {
        }

        public DuplicatedItemException(string message) : base(message)
        {
        }

        public DuplicatedItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicatedItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}