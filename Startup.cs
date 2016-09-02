namespace netcorenancyapp
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using System;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Configuration;
    using Microsoft.AspNetCore.Http;

    public class Startup
    {
        public Startup()
        {
            var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

            Configuration = config;
        }

        public IConfigurationRoot Configuration { get; }
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
          
            app.Run(async (context) =>
            {
                loggerFactory.CreateLogger("MyApp").LogInformation("yo");
                await context.Response.WriteAsync("Hello Nancy World!");
            });
        }
    }
}
