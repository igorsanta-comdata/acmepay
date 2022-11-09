using Acmepay.Application.Persistance;
using Acmepay.Contracts.Payment;
using Acmepay.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Acmepay.Application.Payment.Commands.Voids
{
    public class VoidsCommandHandler : IRequestHandler<VoidsCommand, IActionResult>
    {
        private readonly IPaymentRepository _paymentRepository;

        public VoidsCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IActionResult> Handle(VoidsCommand command, CancellationToken cancellationToken)
        {
            PaymentEntity paymentEntity =  _paymentRepository.GetPaymentById(command.Id);

            if (paymentEntity is null)
            {
                return new NotFoundObjectResult(command.Id);
            }

            paymentEntity.ChangePaymentStatusToVoid();
            paymentEntity.OrderReference = command.OrderReference;

            _paymentRepository.UpdatePayment(paymentEntity);

            return new OkObjectResult(
                new PaymentResponse(
                paymentEntity.PaymentId,
                (int)paymentEntity.PaymentStatus
            ));
        }
    }
}