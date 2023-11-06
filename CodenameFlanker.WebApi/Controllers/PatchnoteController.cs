using CodenameFlanker.Data;
using CodenameFlanker.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace CodenameFlanker.WebApi.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("v1/[controller]")]
public class PatchnoteController : ControllerBase
{
	private readonly CodenameFlankerDbContext _dbContext;

	public PatchnoteController(CodenameFlankerDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	[HttpGet]
	public async Task<List<Patchnote>> GetPatchnotes()
	{
		return await _dbContext.Patchnotes.AsNoTracking().Include(x => x.PatchnoteChanges).ToListAsync();
	}
}
