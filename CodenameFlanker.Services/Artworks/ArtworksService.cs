using CodenameFlanker.Contracts.Artists.Dto;
using CodenameFlanker.Contracts.Artworks.Dto;
using CodenameFlanker.Contracts.Images.Dto;
using CodenameFlanker.Data;
using CodenameFlanker.Data.Entities;
using CodenameFlanker.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CodenameFlanker.Services.Artworks;

public sealed class ArtworksService
{
    private readonly CodenameFlankerDbContext _dbContext;
	private readonly string _webRootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");

	public ArtworksService(CodenameFlankerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ListedArtworkDto>> GetArtworks()
    {
        IReadOnlyCollection<Artwork> artworksDb = await _dbContext.Artworks.AsNoTracking()
            .ToListAsync();

		List<ListedArtworkDto> artworksDto = new List<ListedArtworkDto>();

		foreach (var artwork in artworksDb)
		{
			string base64 = ImageBase64Converter.Convert(Path.Combine(_webRootPath, "artworks", artwork.Thumbnail));
			ListedArtworkDto dto = new ListedArtworkDto(artwork.Id, artwork.Name, artwork.Thumbnail, base64, artwork.ArtistId);
			artworksDto.Add(dto);
		}

		return artworksDto;
    }

	public async Task<ArtworkDto> GetArtworkById(int id)
	{
		Artwork artworkDb = await _dbContext.Artworks.AsNoTracking()
            .Where(x => x.Id == id)
            .Include(x => x.Artist)
            .Include(x => x.Images)
            .FirstOrDefaultAsync();

		if (artworkDb == null)
			throw new Exception();//TO DO

		List<ImageDto> imagesDto = new List<ImageDto>();

		foreach (var image in artworkDb.Images)
		{
			string base64 = ImageBase64Converter.Convert(Path.Combine(_webRootPath, "artworks", image.Path));
			ImageDto dto = new ImageDto(base64, image.Description);
			imagesDto.Add(dto);
		}

		string artistBase64 = ImageBase64Converter.Convert(Path.Combine(_webRootPath, "artists", artworkDb.Artist.Icon));
		ArtistDto artistDto = new ArtistDto(artworkDb.Artist.Id, artworkDb.Artist.Name, artworkDb.Artist.Icon, artistBase64, artworkDb.Artist.Role);

		ArtworkDto artworkDto = new ArtworkDto(artworkDb.Id, artworkDb.Name, imagesDto, artistDto, artworkDb.Description);

		return artworkDto;
	}
}
