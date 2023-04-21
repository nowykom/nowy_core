﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Nowy.Standard;

public static class ServiceCollectionHostedServiceExtensions
{
    public static void AddHostedService<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, IHostedService, TService
    {
        services.AddSingleton<TService, TImplementation>();
        services.AddHostedService<HostedServiceWrapper<TService>>();
    }

    private class HostedServiceWrapper<TService> : IHostedService
    {
        private readonly IHostedService _hostedService;

        public HostedServiceWrapper(TService hostedService)
        {
            this._hostedService = (IHostedService)hostedService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return this._hostedService.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return this._hostedService.StopAsync(cancellationToken);
        }
    }
}
