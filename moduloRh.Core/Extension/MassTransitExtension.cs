using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace moduloRh.Core.Extension;

public static class MassTransitExtension
{
    public static void AddMassTransitExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x => {
            x.AddDelayedMessageScheduler();
            x.SetSnakeCaseEndpointNameFormatter();

            x.UsingRabbitMq((ctx, cfg) => {
                cfg.Host(configuration.GetConnectionString("RabbitMq"));
                cfg.UseDelayedMessageScheduler();
                cfg.ConfigureEndpoints(ctx, new SnakeCaseEndpointNameFormatter("ConsumerMessage", false));
                cfg.UseMessageRetry(retry => { retry.Interval(3, TimeSpan.FromSeconds(5)); });
            });
        });
    }
}

