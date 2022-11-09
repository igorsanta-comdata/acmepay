using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Acmepay.Application.Commands.Authorization
{
    public record AuthorizeCommand(
        decimal Amount,
        string Currency,
        string CardHolderName,
        string HolderName,
        int ExpirationMonth,
        int ExpirationYear,
        int Cvv,
        string OrderReference) : IRequest<IActionResult>;
}
