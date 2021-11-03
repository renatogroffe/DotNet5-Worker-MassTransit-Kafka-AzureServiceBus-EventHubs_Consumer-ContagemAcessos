using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using WorkerConsumerContagem.Messaging;

namespace WorkerConsumerContagem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransitContagem(hostContext.Configuration);
                    services.AddMassTransitHostedService();

                    services.AddHostedService<Worker>();
                });
    }
}