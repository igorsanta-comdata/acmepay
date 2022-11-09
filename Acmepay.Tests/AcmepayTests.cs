using Acmepay.Application.Persistance;
using Acmepay.Domain.Entities;
using Acmepay.Domain.Enums;
using Moq;
using NUnit.Framework;

namespace Acmepay.Tests
{
    public class AcmepayTests
    {
        [Test]
        public void Payment_Status_Is_Changed_to_Authorize()
        {
            Mock<IPaymentRepository> paymentRepository = new Mock<IPaymentRepository>();
            Guid paymentId = Guid.NewGuid();

            PaymentEntity paymentEntity = new PaymentEntity(paymentId, 100, "EUR", "Bank", "TestUser", 6, 2025, 123, "Order Reference");

            paymentRepository.Setup(t => t.Authorize(It.IsAny<PaymentEntity>()))
                   .Callback((PaymentEntity paymentEntity) => {
                       paymentEntity.PaymentStatus = AuthorizationStatusEnum.Authorized;
                   }).Verifiable();
            paymentRepository.Object.Authorize(paymentEntity);

            Assert.That(paymentEntity.PaymentStatus, Is.EqualTo(AuthorizationStatusEnum.Authorized));
        }
    }
}
