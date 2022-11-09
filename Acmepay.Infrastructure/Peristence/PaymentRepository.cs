using Acmepay.Application.Persistance;
using Acmepay.Domain.Entities;
using Acmepay.Infrastructure.Exceptions;
using AcmepayAPI.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Acmepay.Infrastructure.Peristence
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApiContext _apiContext;
        public PaymentRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;

        }
        public void Authorize(PaymentEntity paymentEntity)
        {
            try
            {
                _apiContext.Add(paymentEntity);
                _apiContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new InfrastructureException(ErrorCodes.SaveIntoDBError, ex.Message);
            }
            catch (DbUpdateException)
            {
                throw new InfrastructureException(ErrorCodes.SaveIntoDBError, "Error while saving in database");
            }
            catch (SqlException)
            {
                throw new InfrastructureException(ErrorCodes.DatabaseNotAccessible, "The database was not found or was not accessible");
            }
        }

        public PaymentEntity? GetPaymentById(Guid paymentId)
        {
            try
            {
                return _apiContext.PaymentEntity.FirstOrDefault(payment => payment.PaymentId.Equals(paymentId));
            }
            catch (SqlException)
            {
                throw new InfrastructureException(ErrorCodes.DatabaseNotAccessible, "The database was not found or was not accessible");
            }
        }

        public void UpdatePayment(PaymentEntity paymentEntity)
        {
            try
            {
                _apiContext.Update(paymentEntity);
                _apiContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new InfrastructureException(ErrorCodes.SaveIntoDBError, ex.Message);
            }
            catch (DbUpdateException)
            {
                throw new InfrastructureException(ErrorCodes.SaveIntoDBError, "Error while saving in database");
            }
            catch (SqlException)
            {
                throw new InfrastructureException(ErrorCodes.DatabaseNotAccessible, "The database was not found or was not accessible");
            }
        }

        public PaymentEntity[] GetAllTransactions()
        {
            try
            {
                return _apiContext.PaymentEntity.ToArray();
            }
            catch (SqlException)
            {
                throw new InfrastructureException(ErrorCodes.DatabaseNotAccessible, "The database was not found or was not accessible");
            }
        }
    }
}
