using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProvaSettimana7
{
    class CustomException:Exception
    {
        public CustomException()
        {
        }

        public CustomException(string message)
                : base(message)
        {
        }

        public CustomException(string message, Exception innerException)
                : base(message, innerException)
        {
        }
        protected CustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
