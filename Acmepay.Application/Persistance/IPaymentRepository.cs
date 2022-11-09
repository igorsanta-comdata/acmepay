using Acmepay.Domain.Entities;

namespace Acmepay.Application.Persistance
{
    public interface IPaymentRepository
    {
        void Authorize(PaymentEntity paymentEntity);
        PaymentEntity? GetPaymentById(Guid paymentId);
        void UpdatePayment(PaymentEntity paymentEntity);
        PaymentEntity[] GetAllTransactions();
    }
}
