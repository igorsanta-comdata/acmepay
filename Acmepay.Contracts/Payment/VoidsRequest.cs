namespace Acmepay.Contracts.Payment;

public record VoidsRequest(
        string OrderReference
);