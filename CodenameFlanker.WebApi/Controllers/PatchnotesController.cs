using CodenameFlanker.Data;
using CodenameFlanker.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace CodenameFlanker.WebApi.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("v1/[controller]")]
public class PatchnotesController : ControllerBase
{
	private readonly CodenameFlankerDbContext _dbContext;
	private readonly IWebHostEnvironment _webHostEnvironment;

	public PatchnotesController(CodenameFlankerDbContext dbContext, IWebHostEnvironment webHostEnvironment)
	{
		_dbContext = dbContext;
		_webHostEnvironment = webHostEnvironment;
	}

	[HttpGet]
	public async Task<List<Patchnote>> GetPatchnotes()
	{
		return await _dbContext.Patchnotes.AsNoTracking().Include(x => x.PatchnoteChanges).ToListAsync();
	}

	//[HttpGet]
	//public IActionResult GetFile()
	//{
	//	Byte[] bytes = System.IO.File.ReadAllBytes(Path.Combine(_webHostEnvironment.WebRootPath, "image.png"));
	//	return File(bytes, "image/png");
	//}
}
