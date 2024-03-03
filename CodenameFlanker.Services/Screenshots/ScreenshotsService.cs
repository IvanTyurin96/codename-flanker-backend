using CodenameFlanker.Contracts.Screenshots.Dto;
using CodenameFlanker.Data;
using CodenameFlanker.Data.Entities;
using CodenameFlanker.Services.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CodenameFlanker.Services.Screenshots;

public sealed class ScreenshotsService
{
    private readonly CodenameFlankerDbContext _dbContext;
	private readonly string _webRootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");

	public ScreenshotsService(CodenameFlankerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<ScreenshotDto>> GetScreenshots()
    {
        IReadOnlyCollection<Screenshot> screenshotsDb = await _dbContext.Screenshots.AsNoTracking()
            .OrderBy(x => x.Id)
            .ToListAsync();

		List<ScreenshotDto> screenshotsDto = new List<ScreenshotDto>();

		foreach (var screenshot in screenshotsDb)
		{
			string base64 = ImageBase64Converter.Convert(Path.Combine(_webRootPath, "screenshots", screenshot.Thumbnail));
			ScreenshotDto dto = new ScreenshotDto(screenshot.Id, screenshot.Path, screenshot.Thumbnail, base64);
			screenshotsDto.Add(dto);
		}

		return screenshotsDto;
    }
}
