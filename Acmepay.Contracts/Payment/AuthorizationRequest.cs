namespace Acmepay.Contracts.Payment;

public record AuthorizationRequest(
        decimal Amount,
        string Currency,
        string CardHolderName,
        string HolderName,
        int ExpirationMonth,
        int ExpirationYear,
        int Cvv,
        string OrderReference
);