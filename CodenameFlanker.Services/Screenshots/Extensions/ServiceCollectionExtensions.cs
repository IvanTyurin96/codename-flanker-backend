using Microsoft.Extensions.DependencyInjection;

namespace CodenameFlanker.Services.Screenshots.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddScreenshotsService(this IServiceCollection services)
    {
        services.AddScoped<ScreenshotsService>();
    }
}
