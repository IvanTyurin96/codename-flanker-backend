using Microsoft.Extensions.DependencyInjection;

namespace CodenameFlanker.Services.Documents.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddDocumentsService(this IServiceCollection services)
	{
		services.AddScoped<DocumentsService>();
	}
}