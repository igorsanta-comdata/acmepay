using Acmepay.Application.Payment.Commands.Voids;
using Acmepay.Application.Persistance;
using Acmepay.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Acmepay.Application.Payment.Queries
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IActionResult>
    {
        private readonly IPaymentRepository _paymentRepository;
        public GetAllTransactionsQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<IActionResult> Handle(GetAllTransactionsQuery command, CancellationToken cancellationToken)
        {
            PaymentEntity[] paymentEntities = _paymentRepository.GetAllTransactions();

            if (paymentEntities is null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(paymentEntities);
        }
    }
}
