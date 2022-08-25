using moduloRh.WebApi;
using System.Reflection;

namespace ConsultaLogs.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            //string port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
            //string url = String.Concat("http://0.0.0.0:", port);
            //
            //return Host.CreateDefaultBuilder(args)
            //    .ConfigureWebHostDefaults(webBuilder =>
            //    {
            //        webBuilder.UseStartup<Startup>().UseUrls(url);
            //    });
            return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                string port = Environment.GetEnvironmentVariable("PORT");
                if (port != null && port != "")
                {
                    string url = String.Concat("http://0.0.0.0:", port);
                    webBuilder
                    .UseStartup(Assembly.GetEntryAssembly().FullName)
                    .UseUrls(url);
                }
                else
                {
                    webBuilder.UseStartup(Assembly.GetEntryAssembly().FullName);
                }
            });
        }

    }
}
