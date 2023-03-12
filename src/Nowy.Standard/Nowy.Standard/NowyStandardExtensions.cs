using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Nowy.Standard;

public static class NowyStandardExtensions
{
    public static void AddNowyStandard(this IServiceCollection services)
    {
        services.AddSingleton<FileTypeService>(sp => new FileTypeService(sp.GetRequiredService<ILogger<FileTypeService>>()));
    }
}
