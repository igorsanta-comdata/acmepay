namespace Acmepay.Contracts.Payment;

public record PaymentResponse(
        Guid Id,
        int Status
);