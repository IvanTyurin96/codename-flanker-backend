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
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> Get()
	{
		Thread.Sleep(1000);
		var patchnotes = await _dbContext.Patchnotes.AsNoTracking()
			.Include(x => x.PatchnoteChanges)
			.OrderByDescending(x => x.Id)
			.ToListAsync();
		return Ok(patchnotes);
	}

	//[HttpGet]
	//public IActionResult GetFile()
	//{
	//	Byte[] bytes = System.IO.File.ReadAllBytes(Path.Combine(_webHostEnvironment.WebRootPath, "image.png"));
	//	return File(bytes, "image/png");
	//}
}
