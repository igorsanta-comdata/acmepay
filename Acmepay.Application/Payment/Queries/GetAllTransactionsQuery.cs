using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Acmepay.Application.Payment.Queries
{
    public record GetAllTransactionsQuery() : IRequest<IActionResult>;
}
