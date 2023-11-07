using CodenameFlanker.Data;
using CodenameFlanker.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace CodenameFlanker.WebApi.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("v1/[controller]")]
public class ArtworksController : ControllerBase
{
	private readonly CodenameFlankerDbContext _dbContext;
	private readonly IWebHostEnvironment _webHostEnvironment;

	public ArtworksController(CodenameFlankerDbContext dbContext, IWebHostEnvironment webHostEnvironment)
	{
		_dbContext = dbContext;
		_webHostEnvironment = webHostEnvironment;
	}

	[HttpGet("get")]
	public async Task<IActionResult> GetArtworks()
	{
		var artworks = await _dbContext.Artworks.AsNoTracking()
			.Include(x => x.Images)
			.Include(x => x.Artist).ToListAsync();
		return Ok(artworks);
	}
}
