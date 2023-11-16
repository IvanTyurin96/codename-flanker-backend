using CodenameFlanker.Contracts.Screenshots.Dto;
using CodenameFlanker.Data.Entities;
using CodenameFlanker.Services.Screenshots;
using CodenameFlanker.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CodenameFlanker.WebApi.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("v1/[controller]")]
public class ScreenshotsController : ControllerBase
{
    private readonly ScreenshotsService _screenshotsService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ScreenshotsController(ScreenshotsService screenshotsService, IWebHostEnvironment webHostEnvironment)
    {
        _screenshotsService = screenshotsService;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
		Thread.Sleep(2000);
		List<Screenshot> screenshots = await _screenshotsService.GetScreenshots();

        List<ScreenshotDto> dtoList = new List<ScreenshotDto>();

        foreach(var screenshot in screenshots)
        {
            string base64 = ImageBase64Converter.Convert(Path.Combine(_webHostEnvironment.WebRootPath, "screenshots", screenshot.Thumbnail));
            ScreenshotDto dto = new ScreenshotDto(screenshot.Id, screenshot.Path, screenshot.Thumbnail, base64);
            dtoList.Add(dto);
        }
        return Ok(dtoList);
    }
}
