using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MessengerHelper.Exceptions
{
    public class NotRegisterdMessageException : MessageHelperException
    {
        public NotRegisterdMessageException() { }
        public NotRegisterdMessageException(string message) : base(message) { }
        public NotRegisterdMessageException(string message, Exception innerException) : base(message, innerException) { }
        protected NotRegisterdMessageException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public NotRegisterdMessageException(Type messageType) :
            this(string.Format("{0} is not registered.", messageType.ToString())) { }
    }
}
