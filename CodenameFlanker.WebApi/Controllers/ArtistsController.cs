using CodenameFlanker.Contracts.Artists.Dto;
using CodenameFlanker.Services.Artists;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CodenameFlanker.WebApi.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("v1/[controller]")]
public sealed class ArtistsController : ControllerBase
{
    private readonly ArtistsService _artistsService;

    public ArtistsController(ArtistsService artistsService)
    {
        _artistsService = artistsService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public async Task<IActionResult> Get()
    {
		List<ArtistDto> artists = (List<ArtistDto>)await _artistsService.GetArtists();

        return Ok(artists);
    }
}
