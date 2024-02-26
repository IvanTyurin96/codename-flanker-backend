using CodenameFlanker.Services.Documents;
using Microsoft.AspNetCore.Mvc;

namespace CodenameFlanker.WebApi.Controllers;

[Route("v1/[controller]")]
public sealed class DocumentsController : ControllerBase
{
	private readonly DocumentsService _documentsService;

	public DocumentsController(DocumentsService documentsService)
	{
		_documentsService = documentsService;
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public async Task<IActionResult> Get([FromQuery] string language)
	{
		(byte[] file, string fileType, string fileName) = await _documentsService.GetManual(language);
		return File(file, fileType, fileName);
	}
}
