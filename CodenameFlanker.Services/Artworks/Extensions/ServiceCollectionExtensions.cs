using Microsoft.Extensions.DependencyInjection;

namespace CodenameFlanker.Services.Artworks.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddArtworksService(this IServiceCollection services)
    {
        services.AddScoped<ArtworksService>();
    }
}

