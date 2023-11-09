using CodenameFlanker.Data;
using CodenameFlanker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodenameFlanker.Services.Screenshots;

public class ScreenshotsService
{
    private readonly CodenameFlankerDbContext _dbContext;

    public ScreenshotsService(CodenameFlankerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Screenshot>> GetScreenshots()
    {
        List<Screenshot> screenshots = await _dbContext.Screenshots.AsNoTracking()
            .OrderBy(x => x.Id)
            .ToListAsync();

        return screenshots;
    }
}
