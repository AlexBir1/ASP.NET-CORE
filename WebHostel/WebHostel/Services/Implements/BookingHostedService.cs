﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebHostel.DAL;
using WebHostel.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebHostel.Services.Implements
{
    public class ChecksHostedService : IHostedService, IDisposable
    {
        
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;

        public ChecksHostedService(IServiceScopeFactory scopeFactory)
        {
            // Inject the scope factory
            _scopeFactory = scopeFactory;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
           TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using var scope = _scopeFactory.CreateScope();

            // Get a Dbcontext from the scope
            var context = scope.ServiceProvider
                .GetRequiredService<ApplicationDBContext>();
            context.Database.ExecuteSqlRaw("call DelBookingNotAttend()");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 10);

            return Task.CompletedTask;
        }
    }
}
