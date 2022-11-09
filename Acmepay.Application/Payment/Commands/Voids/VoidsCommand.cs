using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Acmepay.Application.Payment.Commands.Voids
{
    public record VoidsCommand(
        Guid Id,
        string OrderReference) : IRequest<IActionResult>;
}
