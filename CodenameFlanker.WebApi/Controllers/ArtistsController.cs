using CodenameFlanker.Contracts.Artists.Dto;
using CodenameFlanker.Data.Entities;
using CodenameFlanker.Services.Artists;
using CodenameFlanker.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CodenameFlanker.WebApi.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("v1/[controller]")]
public class ArtistsController : ControllerBase
{
    private readonly ArtistsService _artistsService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ArtistsController(ArtistsService artistsService, IWebHostEnvironment webHostEnvironment)
    {
        _artistsService = artistsService;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
		Thread.Sleep(5000);
		List<Artist> artists = await _artistsService.GetArtists();

        List<ArtistDto> listDto = new List<ArtistDto>();
        foreach (var artist in artists) 
        {
            string base64 = ImageBase64Converter.Convert(Path.Combine(_webHostEnvironment.WebRootPath, "artists", artist.Icon));
            ArtistDto dto = new ArtistDto(artist.Id, artist.Name, artist.Icon, base64, artist.Role);
            listDto.Add(dto);
        }
        return Ok(listDto);
    }
}
