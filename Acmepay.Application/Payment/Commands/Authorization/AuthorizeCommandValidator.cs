using Acmepay.Application.Commands.Authorization;
using FluentValidation;

namespace Acmepay.Application.Payment.Commands.Authorization
{
    public class AuthorizeCommandValidator : AbstractValidator<AuthorizeCommand>
    {
        public AuthorizeCommandValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.CardHolderName).NotEmpty();
            RuleFor(x => x.Currency).NotEmpty();
            RuleFor(x => x.Cvv).NotEmpty();
            RuleFor(x => x.HolderName).NotEmpty();
            RuleFor(x => x.ExpirationMonth).NotEmpty();
            RuleFor(x => x.ExpirationYear).NotEmpty();
            RuleFor(x => x.OrderReference).NotEmpty();
        }
    }
}
