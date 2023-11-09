using Microsoft.Extensions.DependencyInjection;

namespace CodenameFlanker.Services.Artists.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddArtistsService(this IServiceCollection services)
    {
        services.AddScoped<ArtistsService>();
    }
}
