using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acmepay.Application.Exceptions
{
    public class AppException : Exception
    {
        public AppException(ErrorCodes errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCodes ErrorCode { get; private set; }
    }
}
