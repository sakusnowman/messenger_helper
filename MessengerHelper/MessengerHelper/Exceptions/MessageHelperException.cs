using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MessengerHelper.Exceptions
{
    public class MessageHelperException : Exception
    {
        public MessageHelperException() { }
        public MessageHelperException(string message) : base(message) { }
        public MessageHelperException(string message, Exception innerException) : base(message, innerException) { }
        protected MessageHelperException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
