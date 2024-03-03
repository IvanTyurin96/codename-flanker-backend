using CodenameFlanker.Contracts.Artists.Dto;
using CodenameFlanker.Data;
using CodenameFlanker.Data.Entities;
using CodenameFlanker.Services.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CodenameFlanker.Services.Artists;

public sealed class ArtistsService
{
	private readonly CodenameFlankerDbContext _dbContext;
	private readonly string _webRootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");

	public ArtistsService(CodenameFlankerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<ArtistDto>> GetArtists()
    {
        IReadOnlyCollection<Artist> artistsDb = await _dbContext.Artists.AsNoTracking()
            .ToListAsync();

		IReadOnlyCollection<ArtistDto> artistsDto = artistsDb.Select(artist => 
			new ArtistDto(
				artist.Id,
				artist.Name,
				artist.Icon,
				ImageBase64Converter.Convert(Path.Combine(_webRootPath, "artists", artist.Icon)),
				artist.Role))
			.ToList();

		return artistsDto;
    }
}
