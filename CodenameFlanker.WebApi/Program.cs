using CodenameFlanker.Data;
using Microsoft.EntityFrameworkCore;
using CodenameFlanker.Services.Screenshots.Extensions;
using CodenameFlanker.Services.Patchnotes.Extensions;
using CodenameFlanker.Services.Artworks.Extensions;
using CodenameFlanker.Services.Artists.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CodenameFlankerDbContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("CodenameFlanker")));

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

app.MapControllers();

app.Run();
