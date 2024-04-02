using CodenameFlanker.Data;
using CodenameFlanker.Services.Artists.Extensions;
using CodenameFlanker.Services.Artworks.Extensions;
using CodenameFlanker.Services.Documents.Extensions;
using CodenameFlanker.Services.Patchnotes.Extensions;
using CodenameFlanker.Services.Screenshots.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.WebHost.ConfigureKestrel((context, serverOptions) =>
{
	var kestrelSection = context.Configuration.GetSection("Kestrel");
	serverOptions.Configure(kestrelSection);
});

// Add services to the container.
string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodenameFlanker.db");
builder.Services.AddDbContext<CodenameFlankerDbContext>(
	options => options.UseSqlite($"Filename={path}"));

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddRequestTimeouts();

builder.Services.AddArtworksService();
builder.Services.AddPatchnotesService();
builder.Services.AddScreenshotsService();
builder.Services.AddArtistsService();
builder.Services.AddDocumentsService();

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();
app.UseRequestTimeouts();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseHsts();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors(cors => cors
	.AllowAnyMethod()
	.AllowAnyHeader()
	.SetIsOriginAllowed(origin => true));

app.UseMiddleware<CodenameFlanker.WebApi.Handlers.ExceptionHandlerMiddleware>();

app.MapControllers().WithRequestTimeout(TimeSpan.FromMilliseconds(10000));

app.Run();
