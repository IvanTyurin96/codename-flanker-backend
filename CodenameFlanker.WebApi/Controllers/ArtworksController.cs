using CodenameFlanker.Contracts.Artworks.Dto;
using CodenameFlanker.Data;
using CodenameFlanker.Data.Entities;
using CodenameFlanker.Services.Artworks;
using CodenameFlanker.WebApi.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace CodenameFlanker.WebApi.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("v1/[controller]")]
public class ArtworksController : ControllerBase
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
    public async Task<IActionResult> Get()
	{
        List<Artwork> artworks = await _artworksService.GetArtworks();

		List<ArtworkDto> dtoList = new List<ArtworkDto>();

		foreach(var artwork in artworks) 
		{
			string base64 = ImageBase64Converter.Convert(Path.Combine(_webHostEnvironment.WebRootPath, "artworks", artwork.Thumbnail));
			ArtworkDto dto = new ArtworkDto(artwork.Id, artwork.Name, artwork.Thumbnail, base64, artwork.ArtistId, artwork.Description);
			dtoList.Add(dto);
		}

        return Ok(dtoList);
	}
}
