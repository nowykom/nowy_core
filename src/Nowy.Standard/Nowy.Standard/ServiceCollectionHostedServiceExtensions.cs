using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Nowy.Standard;

public static class ServiceCollectionHostedServiceExtensions
{
    public static void AddHostedServiceByWrapper<TService>(this IServiceCollection services)
        where TService : class, IHostedService
    {
        services.AddHostedService<HostedServiceWrapper<TService>>(sp => new HostedServiceWrapper<TService>(sp.GetRequiredService<TService>()));
    }

    private class HostedServiceWrapper<TService> : IHostedService
    {
        private readonly IHostedService _hostedService;

        public HostedServiceWrapper(TService hostedService)
        {
            _hostedService = (IHostedService)hostedService;
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
