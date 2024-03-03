using CodenameFlanker.Contracts.Artworks.Dto;
using CodenameFlanker.Services.Artworks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CodenameFlanker.WebApi.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("v1/[controller]")]
public sealed class ArtworksController : ControllerBase
{
	private readonly ArtworksService _artworksService;

	public ArtworksController(ArtworksService artworksService)
	{
		_artworksService = artworksService;
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public async Task<IActionResult> Get()
	{
		List<ListedArtworkDto> artworks = 
			(List<ListedArtworkDto>)await _artworksService.GetArtworks();

		return Ok(artworks);
	}

	[HttpGet("{id:int:min(1)}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public async Task<IActionResult> GetById([FromRoute] int id)
	{
		ArtworkDto artwork = await _artworksService.GetArtworkById(id);

		if (artwork == null)
			return NotFound($"Artwork with id = {id} not found.");

		return Ok(artwork);
	}
}
