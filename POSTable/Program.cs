using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace POSTable
{
    public class Program
    {
        /// <summary>
        /// The Main Program for building background ground
        /// </summary>
        /// <param name="args">the startup program arguments</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// the static HostBuilder used for linking the C# code to the HTML Web Page
        /// </summary>
        /// <param name="args">the main arguments for the program</param>
        /// <returns>the HTML IHost</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
