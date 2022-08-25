using System.Reflection;

namespace moduloRh.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                string port = Environment.GetEnvironmentVariable("PORT");
                if (port != null && port != "")
                {
                    string url = string.Concat("http://0.0.0.0:", port);
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
