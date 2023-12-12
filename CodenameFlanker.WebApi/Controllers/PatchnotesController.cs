using CodenameFlanker.Data.Entities;
using CodenameFlanker.Services.Patchnotes;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CodenameFlanker.WebApi.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("v1/[controller]")]
public class PatchnotesController : ControllerBase
{
	private readonly PatchnotesService _patchnotesService;

	public PatchnotesController(PatchnotesService patchnotesService)
	{
        _patchnotesService = patchnotesService;
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> Get()
	{
		List<Patchnote> patchnotes = await _patchnotesService.GetPatchnotes();

        return Ok(patchnotes);
	}
}
