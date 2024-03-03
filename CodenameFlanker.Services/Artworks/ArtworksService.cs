using CodenameFlanker.Contracts.Artworks.Dto;
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

	public async Task<Artwork?> GetArtworkById(int id)
	{
		Artwork? artwork = await _dbContext.Artworks.AsNoTracking()
            .Where(x => x.Id == id)
            .Include(x => x.Artist)
            .Include(x => x.Images)
            .FirstOrDefaultAsync();

		return artwork;
	}
}
