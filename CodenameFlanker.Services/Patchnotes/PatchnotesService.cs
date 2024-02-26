using CodenameFlanker.Data;
using CodenameFlanker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodenameFlanker.Services.Patchnotes;

public sealed class PatchnotesService
{
    private readonly CodenameFlankerDbContext _dbContext;

    public PatchnotesService(CodenameFlankerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Patchnote>> GetPatchnotes()
    {
        List<Patchnote> patchnotes = await _dbContext.Patchnotes.AsNoTracking()
            .Include(x => x.PatchnoteChanges)
            .OrderByDescending(x => x.Id)
            .ToListAsync();

        return patchnotes;
    }
}
