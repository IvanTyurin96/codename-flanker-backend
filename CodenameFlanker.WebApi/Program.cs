using CodenameFlanker.Data;
using Microsoft.EntityFrameworkCore;
using CodenameFlanker.Services.Screenshots.Extensions;
using CodenameFlanker.Services.Patchnotes.Extensions;
using CodenameFlanker.Services.Artworks.Extensions;
using CodenameFlanker.Services.Artists.Extensions;
using CodenameFlanker.WebApi.Handlers;
using Serilog;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "CodenameFlanker.db");
builder.Services.AddDbContext<CodenameFlankerDbContext>(
	options => options.UseSqlite($"Filename={path}"));

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddArtworksService();
builder.Services.AddPatchnotesService();
builder.Services.AddScreenshotsService();
builder.Services.AddArtistsService();

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

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

app.MapControllers();

app.Run();
