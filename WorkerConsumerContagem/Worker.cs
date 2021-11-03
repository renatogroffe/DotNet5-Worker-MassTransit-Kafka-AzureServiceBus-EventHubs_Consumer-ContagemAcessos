using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerConsumerContagem
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly int _intervaloMensagemWorkerAtivo;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _intervaloMensagemWorkerAtivo =
                Convert.ToInt32(configuration["IntervaloMensagemWorkerAtivo"]);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //await _busControl.StartAsync(stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation(
                    $"Worker ativo em: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                await Task.Delay(_intervaloMensagemWorkerAtivo, stoppingToken);
            }
        }
    }
}