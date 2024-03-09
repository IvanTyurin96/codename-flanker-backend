using CodenameFlanker.Contracts.Artists.Dto;
using CodenameFlanker.Contracts.Artworks.Dto;
using CodenameFlanker.Contracts.Images.Dto;
using CodenameFlanker.Data;
using CodenameFlanker.Data.Entities;
using CodenameFlanker.Services.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CodenameFlanker.Services.Artworks;

public sealed class ArtworksService
{
    private readonly CodenameFlankerDbContext _dbContext;
	private readonly string _webRootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");

	public ArtworksService(CodenameFlankerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<ListedArtworkDto>> GetArtworks()
    {
        IReadOnlyCollection<Artwork> artworksDb = await _dbContext.Artworks.AsNoTracking()
			.ToListAsync();

		IReadOnlyCollection<ListedArtworkDto> artworksDto = artworksDb.Select(artwork => 
			new ListedArtworkDto(
				artwork.Id, 
				artwork.Name, 
				artwork.Thumbnail,
				ImageBase64Converter.Convert(Path.Combine(_webRootPath, "artworks", artwork.Thumbnail)), 
				artwork.ArtistId))
			.ToList();

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

		IReadOnlyCollection<ImageDto> imagesDto = artworkDb.Images.Select(image =>
			new ImageDto(
				ImageBase64Converter.Convert(Path.Combine(_webRootPath, "artworks", image.Path)),
				image.Description))
			.ToList();

		string artistBase64 = ImageBase64Converter.Convert(Path.Combine(_webRootPath, "artists", artworkDb.Artist.Icon));
		ArtistDto artistDto = new ArtistDto(artworkDb.Artist.Id, artworkDb.Artist.Name, artworkDb.Artist.Icon, artistBase64, artworkDb.Artist.Role);

		ArtworkDto artworkDto = new ArtworkDto(artworkDb.Id, artworkDb.Name, imagesDto, artistDto, artworkDb.Description);

		return artworkDto;
	}
}
