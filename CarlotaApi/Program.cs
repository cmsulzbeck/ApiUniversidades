using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace CarlotaApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseKestrel(options => 
                    {
                        int port = 5443;
                        if (args.Length > 0)
                            int.TryParse(args[0], out port);
                        if (args.Length > 2)
                        {
                            options.ListenAnyIP(port, ListenOptions =>
                            {
                                ListenOptions.UseHttps(args[1], args[2]); // cert.pfx and password
                            });
                        }
                        else
                        {
                            options.ListenAnyIP(port); // if no cert and password are specified then run the server as HTTP one
                        }
                    });
                });
    }
}
