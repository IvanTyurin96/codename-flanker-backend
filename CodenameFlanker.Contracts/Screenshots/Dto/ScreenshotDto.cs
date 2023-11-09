namespace CodenameFlanker.Contracts.Screenshots.Dto;

public record ScreenshotDto
(
    int Id,
    string Path,
    string Thumbnail,
    string ThumbnailBytes
);
