using CodenameFlanker.Services.Documents;
using Microsoft.AspNetCore.Mvc;

namespace CodenameFlanker.WebApi.Controllers;

[Route("v1/[controller]")]
public sealed class DocumentsController : ControllerBase
{
	private readonly IWebHostEnvironment _webHostEnvironment;

	private readonly DocumentsService _documentsService;

	public DocumentsController(IWebHostEnvironment webHostEnvironment, DocumentsService documentsService)
	{
		_webHostEnvironment = webHostEnvironment;
		_documentsService = documentsService;
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
