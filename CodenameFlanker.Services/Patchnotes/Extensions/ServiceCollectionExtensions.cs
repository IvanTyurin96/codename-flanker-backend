using Microsoft.Extensions.DependencyInjection;

namespace CodenameFlanker.Services.Patchnotes.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddPatchnotesService(this IServiceCollection services)
    {
        services.AddScoped<PatchnotesService>();
    }
}
