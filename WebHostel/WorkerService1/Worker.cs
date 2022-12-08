using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebHostel.DAL;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ChecksRepository Crep;
        public Worker(ChecksRepository _c)
        {
            Crep = _c;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Crep.CheckExpire();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
