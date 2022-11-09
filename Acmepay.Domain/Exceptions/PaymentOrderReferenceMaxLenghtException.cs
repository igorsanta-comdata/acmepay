using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acmepay.Domain.Exceptions
{
    public class PaymentOrderReferenceMaxLenghtException : DomainException
    {
        public PaymentOrderReferenceMaxLenghtException(ErrorCodes errorCode, string message) : base(errorCode, message) { }
    }
}
