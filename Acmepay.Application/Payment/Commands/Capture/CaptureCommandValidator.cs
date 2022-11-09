using Acmepay.Application.Payment.Commands.Voids;
using FluentValidation;

namespace Acmepay.Application.Payment.Commands.Capture
{
    public class CaptureCommandValidator : AbstractValidator<VoidsCommand>
    {
        public CaptureCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.OrderReference).NotEmpty();
        }
    }
}
