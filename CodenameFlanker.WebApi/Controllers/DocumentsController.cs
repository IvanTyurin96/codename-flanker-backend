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
		string selectedFile;
		switch (language)
		{
			case "en":
				selectedFile = "Su-30 EFM Documentation EN.pdf";
				break;
			case "ru":
				selectedFile = "Su-30 EFM Documentation RU.pdf";
				break;
			default:
				return NotFound("Documentation for this language not found.");
		}

		string path = Path.Combine(_webHostEnvironment.WebRootPath, "docs", selectedFile);

		string fileType = "application/pdf";
		string fileName = Path.GetFileName(path);

		return PhysicalFile(path, fileType, fileName);
	}
}
