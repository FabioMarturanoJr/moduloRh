using Microsoft.OpenApi.Models;
using moduloRh.Core.Extension;
using moduloRh.Infrastructure.IoC;
using moduloRh.WebApi.Configuration;

namespace moduloRh.WebApi
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IWebHostEnvironment environment)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ApiServiceConfig();
            services.AddDependencies(_configuration);
            services.AddMassTransitExtension(_configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "moduloRh.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                Console.WriteLine(env);
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "moduloRh.Api v1"));

            app.UseAuthentication();
            app.UseAuthorization();

            app.ApiApplicationConfig(env);
        }
    }
}
