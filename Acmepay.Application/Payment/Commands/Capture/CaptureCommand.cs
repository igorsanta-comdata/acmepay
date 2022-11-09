using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Acmepay.Application.Payment.Commands.Capture
{
    public record CaptureCommand(
        Guid Id,
        string OrderReference) : IRequest<IActionResult>;
}
