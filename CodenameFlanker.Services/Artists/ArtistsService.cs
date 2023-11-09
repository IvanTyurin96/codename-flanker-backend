using CodenameFlanker.Data.Entities;
using CodenameFlanker.Data;
using Microsoft.EntityFrameworkCore;

namespace CodenameFlanker.Services.Artists;

public class ArtistsService
{
    private readonly CodenameFlankerDbContext _dbContext;

    public ArtistsService(CodenameFlankerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Artist>> GetArtists()
    {
        List<Artist> artists = await _dbContext.Artists.AsNoTracking()
            .ToListAsync();

        return artists;
    }
}
