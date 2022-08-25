using Microsoft.Extensions.DependencyInjection;

namespace moduloRh.AutoMapping.DI
{
    public static class ServiceCollectionExtensor
    {
        public static void AddAutoMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);
        }
    }
}
