using Microsoft.AspNetCore.Mvc;

namespace CodenameFlanker.WebApi.Controllers;

[Route("v1/[controller]")]
public class DocumentsController : ControllerBase
{
	private readonly IWebHostEnvironment _webHostEnvironment;

	public DocumentsController(IWebHostEnvironment webHostEnvironment)
	{
		_webHostEnvironment = webHostEnvironment;
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public IActionResult Get([FromQuery] string language)
	{
		if (String.IsNullOrWhiteSpace(language) || (language.ToLower() != "en" && language.ToLower() != "ru"))
			return NotFound("Documentation for this language not found.");

		string selectedFile = language.ToLower() == "en" ? "Su-30 EFM Documentation EN.pdf" : "Su-30 EFM Documentation RU.pdf";
		string path = Path.Combine(_webHostEnvironment.WebRootPath, "docs", selectedFile);

		string fileType = "application/pdf";
		string fileName = Path.GetFileName(path);

		return PhysicalFile(path, fileType, fileName);
	}
}
