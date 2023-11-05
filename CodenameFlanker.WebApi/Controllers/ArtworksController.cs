using CodenameFlanker.Data;
using CodenameFlanker.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace CodenameFlanker.WebApi.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("v1/[controller]")]
public class ArtworksController : ControllerBase
{
	private readonly CodenameFlankerDbContext _dbContext;

	public ArtworksController(CodenameFlankerDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	[HttpGet]
	public async Task<List<Artwork>> GetArtworks()
	{
		return await _dbContext.Artworks.AsNoTracking().Include(x => x.Images).ToListAsync();
	}
}
