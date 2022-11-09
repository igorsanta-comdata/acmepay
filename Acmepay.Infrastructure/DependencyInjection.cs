using Acmepay.Application.Persistance;
using Acmepay.Infrastructure.Peristence;
using Microsoft.Extensions.DependencyInjection;

namespace Acmepay.Application;

public static class DependencyInjection
{
    public static IServiceCollection Addinfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        return services;
    }
}