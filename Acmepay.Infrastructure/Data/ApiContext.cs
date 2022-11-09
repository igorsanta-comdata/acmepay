using Acmepay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcmepayAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<PaymentEntity> PaymentEntity { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }
    }
}
