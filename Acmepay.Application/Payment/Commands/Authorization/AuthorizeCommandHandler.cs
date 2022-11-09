using Acmepay.Application.Persistance;
using Acmepay.Contracts.Payment;
using Acmepay.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Acmepay.Application.Commands.Authorization
{
    public class AuthorizeCommandHandler : IRequestHandler<AuthorizeCommand, IActionResult>
    {
        private readonly IPaymentRepository _paymentRepository;

        public AuthorizeCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IActionResult> Handle(AuthorizeCommand command, CancellationToken cancellationToken)
        {
            var payment = PaymentEntity.Create(
                Guid.NewGuid(),
                command.Amount,
                command.Currency,
                command.CardHolderName,
                command.HolderName,
                command.ExpirationMonth,
                command.ExpirationYear,
                command.Cvv,
                command.OrderReference);

            try
            {
                _paymentRepository.Authorize(payment);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

            return new OkObjectResult(new PaymentResponse(
                payment.PaymentId,
                (int)payment.PaymentStatus
            ));
        }
    }
}
