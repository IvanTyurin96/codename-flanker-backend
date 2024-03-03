using CodenameFlanker.Contracts.PatchnoteChanges.Dto;
using CodenameFlanker.Contracts.Patchnotes.Dto;
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

    public async Task<IReadOnlyCollection<PatchnoteDto>> GetPatchnotes()
    {
		IReadOnlyCollection<Patchnote> patchnotesDb = await _dbContext.Patchnotes.AsNoTracking()
            .Include(x => x.PatchnoteChanges)
            .OrderByDescending(x => x.Id)
            .ToListAsync();

		IReadOnlyCollection<PatchnoteDto> patchnotesDto = patchnotesDb.Select(patchnote => 
            new PatchnoteDto(patchnote.Id, patchnote.Version, patchnote.PatchnoteChanges.Select(change => 
                new PatchnoteChangeDto(change.Id, change.Name, change.Change, change.PatchnoteId)).ToList()))
            .ToList();

		return patchnotesDto;
    }
}
