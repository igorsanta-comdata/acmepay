using FluentValidation;

namespace Acmepay.Application.Payment.Commands.Voids
{
    public class VoidsCommandValidator : AbstractValidator<VoidsCommand>
    {
        public VoidsCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.OrderReference).NotEmpty();
        }
    }
}
