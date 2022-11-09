using Microsoft.EntityFrameworkCore;

namespace Acmepay.Domain.Primitives
{
    [Index(nameof(PaymentId), IsUnique = true)]
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity(Guid paymentId)
        {
            PaymentId = paymentId;
        }

        public Guid PaymentId { get; private init; }

        public static bool operator ==(Entity? first, Entity? second)
        {
            return first is not null && second is not null && first.Equals(second);
        }

        public static bool operator !=(Entity? first, Entity? second)
        {
            return !(first == second);
        }
        public bool Equals(Entity? other)
        {
            if(other is null)
            {
                return false;
            }

            if(other.GetType() != GetType())
            {
                return false;
            }

            return other.PaymentId == PaymentId;
        }
        public override bool Equals(object? obj)
        {
            if(obj is null)
            {
                return false;
            }

            if(obj.GetType() != GetType())
            {
                return false;
            }

            if(obj is not Entity entity)
            {
                return false;
            }

            return entity.PaymentId == PaymentId;
        }

        public override int GetHashCode()
        {
            return PaymentId.GetHashCode();
        }
    }
}
