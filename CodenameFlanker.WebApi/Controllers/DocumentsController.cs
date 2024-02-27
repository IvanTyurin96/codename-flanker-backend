using CodenameFlanker.Services.Documents;
using Microsoft.AspNetCore.Mvc;

namespace CodenameFlanker.WebApi.Controllers;

[Route("v1/[controller]")]
public sealed class DocumentsController : ControllerBase
{
	private readonly string _domainDirectory = AppDomain.CurrentDomain.BaseDirectory;
	private readonly DocumentsService _documentsService;

	public DocumentsController(DocumentsService documentsService)
	{
		_documentsService = documentsService;
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public IActionResult Get([FromQuery] string language)
	{
		(string fileFolder, string fileType, string fileName) = _documentsService.GetManual(language);
		string filePath = Path.Combine(_domainDirectory, fileFolder, fileName);

		return PhysicalFile(filePath, fileType, fileName);
	}
}
