namespace CodenameFlanker.Contracts.Artworks.Dto;

public record ArtworkListDto
(
    int Id,
    string Name,
	string Thumbnail,
	string ThumbnailBytes,
    int ArtistId
);