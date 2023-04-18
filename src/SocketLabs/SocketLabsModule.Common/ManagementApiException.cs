using SocketLabsModule.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SocketLabsModule.Common
{
    public class ManagementApiException : Exception
    {
        public IEnumerable<ManagementApiException> InnerExceptions { get; private set; }

        public ManagementApiException()
        {
        }

        public ManagementApiException(string message) 
            : base(message)
        {
        }

        public ManagementApiException(string message, IEnumerable<ApiError> errors) 
            : base(message)
        {
            InnerExceptions = errors?.Select(x => new ManagementApiException($"{x.ErrorType}: {x.Message}"));
        }

        public ManagementApiException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected ManagementApiException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
