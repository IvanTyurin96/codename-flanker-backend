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
