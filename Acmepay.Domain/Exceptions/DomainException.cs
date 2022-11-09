using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acmepay.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(ErrorCodes errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCodes ErrorCode { get; private set; }
    }
}
