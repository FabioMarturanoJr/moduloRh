using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using moduloRh.Application.Interfaces;
using moduloRh.Application.Services;
using moduloRh.AutoMapping.DI;
using moduloRh.Infra.Data.Context;
using moduloRh.Infra.Data.Interface;
using moduloRh.Infra.Data.Repositories;

namespace moduloRh.Infrastructure.IoC
{
    public static class NativeCoreDependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapping();

            #region Repositorios
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileService, FileService>();
            #endregion

            #region Contextos
            services.AddDbContext<RhContext>(op =>
                op.UseNpgsql(configuration["ConnectionStrings:ConnectionString"]));
            #endregion
        }
    }
}