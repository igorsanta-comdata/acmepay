namespace Acmepay.Infrastructure.Exceptions
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException(ErrorCodes errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCodes ErrorCode { get; private set; }
    }
}
