using Acmepay.Application.Commands.Authorization;
using Acmepay.Application.Payment.Commands.Capture;
using Acmepay.Application.Payment.Commands.Voids;
using Acmepay.Application.Payment.Queries;
using Acmepay.Contracts.Payment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Acmepay.Api.Controllers;

[ApiController]
[Route("api")]
public class PaymentController : ControllerBase
{
    private readonly ISender _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create a payment based on provided parameters and stored it into database
    /// with authorized status.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>The task result from mediatr. </returns>
    [HttpPost("authorize")]
    public async Task<IActionResult> AuthorizePayment(AuthorizationRequest request)
    {
        var command = new AuthorizeCommand(request.Amount,
            request.Currency,
            request.CardHolderName,
            request.HolderName,
            request.ExpirationMonth,
            request.ExpirationYear,
            request.Cvv,
            request.OrderReference);

        return await _mediator.Send(command);
    }
    /// <summary>
    /// Update the Payment status and reference order value.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns>The task result from mediatr.</returns>
    [HttpPost("authorize/{id}/voids")]
    public async Task<IActionResult> VoidPayment(Guid id, VoidsRequest request)
    {
        var command = new VoidsCommand(id, request.OrderReference);

        return await _mediator.Send(command);
    }

    /// <summary>
    /// Update the Payment status and reference order value.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>The task result from mediatr.</returns>
    [HttpPost("authorize/{id}/capture")]
    public async Task<IActionResult> CapturePayment(Guid id, CapturedRequest request)
    {
        var command = new CaptureCommand(id, request.OrderReference);
        return await _mediator.Send(command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransactions()
    {
        var query = new GetAllTransactionsQuery();
        return await _mediator.Send(query);
    }
}