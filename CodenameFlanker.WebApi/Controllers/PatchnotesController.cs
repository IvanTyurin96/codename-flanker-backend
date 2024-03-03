using CodenameFlanker.Contracts.Patchnotes.Dto;
using CodenameFlanker.Services.Patchnotes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Net.Mime;

namespace CodenameFlanker.WebApi.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("v1/[controller]")]
public sealed class PatchnotesController : ControllerBase
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
		List<PatchnoteDto> patchnotes = 
			(List<PatchnoteDto>)await _patchnotesService.GetPatchnotes();

        return Ok(patchnotes);
	}
}
