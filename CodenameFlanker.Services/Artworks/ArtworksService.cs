using CodenameFlanker.Data;
using CodenameFlanker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodenameFlanker.Services.Artworks;

public class ArtworksService
{
    private readonly CodenameFlankerDbContext _dbContext;

    public ArtworksService(CodenameFlankerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Artwork>> GetArtworks()
    {
        List<Artwork> artworks = await _dbContext.Artworks.AsNoTracking()
            .ToListAsync();

        return artworks;
    }
}
