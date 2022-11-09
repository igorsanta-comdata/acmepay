namespace Acmepay.Contracts.Payment;

public record CapturedRequest(
        Guid Id,
        string OrderReference
);