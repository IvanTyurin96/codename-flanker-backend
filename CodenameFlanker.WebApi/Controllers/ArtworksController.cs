using CodenameFlanker.Contracts.Artists.Dto;
using CodenameFlanker.Contracts.Artworks.Dto;
using CodenameFlanker.Contracts.Images.Dto;
using CodenameFlanker.Data.Entities;
using CodenameFlanker.Services.Artworks;
using CodenameFlanker.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CodenameFlanker.WebApi.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("v1/[controller]")]
public sealed class ArtworksController : ControllerBase
{
	private readonly ArtworksService _artworksService;
	private readonly IWebHostEnvironment _webHostEnvironment;

	public ArtworksController(ArtworksService artworksService, IWebHostEnvironment webHostEnvironment)
	{
		_artworksService = artworksService;
		_webHostEnvironment = webHostEnvironment;
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public async Task<IActionResult> Get()
	{
		List<ListedArtworkDto> artworks = await _artworksService.GetArtworks();

		return Ok(artworks);
	}

	[HttpGet("{id:int:min(1)}")]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetById([FromRoute] int id)
	{
		Artwork artwork = await _artworksService.GetArtworkById(id);

		if (artwork == null)
			return NotFound($"Artwork with id = {id} not found.");

		List<ImageDto> dtoList = new List<ImageDto>();

		foreach (Image image in artwork.Images)
		{
			string base64 = ImageBase64Converter.Convert(Path.Combine(_webHostEnvironment.WebRootPath, "artworks", image.Path));
			ImageDto imageDto = new ImageDto(base64, image.Description);
			dtoList.Add(imageDto);
		}

		string artistBase64 = ImageBase64Converter.Convert(Path.Combine(_webHostEnvironment.WebRootPath, "artists", artwork.Artist.Icon));
		ArtistDto artistDto = new ArtistDto(artwork.Artist.Id, artwork.Artist.Name, artwork.Artist.Icon, artistBase64, artwork.Artist.Role);
		ArtworkDto artworkDto = new ArtworkDto(artwork.Id, artwork.Name, dtoList, artistDto, artwork.Description);
		return Ok(artworkDto);
	}
}
