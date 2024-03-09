using CodenameFlanker.Contracts.Screenshots.Dto;
using CodenameFlanker.Services.Screenshots;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Net.Mime;

namespace CodenameFlanker.WebApi.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("v1/[controller]")]
public sealed class ScreenshotsController : ControllerBase
{
    private readonly ScreenshotsService _screenshotsService;

    public ScreenshotsController(ScreenshotsService screenshotsService)
    {
        _screenshotsService = screenshotsService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public async Task<IActionResult> Get()
    {
		List<ScreenshotDto> screenshots = 
            (List<ScreenshotDto>)await _screenshotsService.GetScreenshots();

        return Ok(screenshots);
    }
}
