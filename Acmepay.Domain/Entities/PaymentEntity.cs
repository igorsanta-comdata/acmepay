using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Acmepay.Domain.Enums;
using System;
using Acmepay.Domain.Primitives;
using Acmepay.Domain.Exceptions;
using System.Configuration;

namespace Acmepay.Domain.Entities
{
    [Index(nameof(PaymentId), IsUnique = true)]
    public class PaymentEntity : Entity
    {
        public PaymentEntity(
            Guid paymentId, 
            decimal amount, 
            string currency, 
            string cardHolderName, 
            string holderName, 
            int expirationMonth, 
            int expirationYear, 
            int cvv, 
            string orderReference) : base(paymentId)
        {
            Amount = amount;
            Currency = currency;
            CardHolderName = cardHolderName;
            HolderName = holderName;
            ExpirationMonth = expirationMonth;
            ExpirationYear = expirationYear;
            Cvv = cvv;
            OrderReference = orderReference;

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string CardHolderName { get; set; }
        public string HolderName { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int Cvv { get; set; }

        //[StringValidator(MaxLength = 50)]
        public string OrderReference { get; set; }
        public AuthorizationStatusEnum PaymentStatus { get; set; }

        public void ChangePaymentStatusToVoid()
        {
            PaymentStatus = AuthorizationStatusEnum.Voided;
        }

        public void ChangePaymentStatusToCaptured()
        {
            PaymentStatus = AuthorizationStatusEnum.Captured;
        }

        public static PaymentEntity Create(
            Guid paymentId,
            decimal amount,
            string currency,
            string cardHolderName,
            string holderName,
            int expirationMonth,
            int expirationYear,
            int cvv,
            string orderReference)
        {
            if(orderReference.Length > 50)
            {
                throw new PaymentOrderReferenceMaxLenghtException(ErrorCodes.MaxNumberOfCharacterExceeded, "Number of character must be less the 50.");
            }

            var paymentEntity = new PaymentEntity(
                paymentId,
                amount,
                currency,
                cardHolderName,
                holderName,
                expirationMonth,
                expirationYear,
                cvv,
                orderReference);

            return paymentEntity;
        }
    }
}
