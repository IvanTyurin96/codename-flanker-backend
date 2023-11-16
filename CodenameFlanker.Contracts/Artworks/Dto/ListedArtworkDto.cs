namespace CodenameFlanker.Contracts.Artworks.Dto;

public record ListedArtworkDto
(
    int Id,
    string Name,
	string Thumbnail,
	string ThumbnailBytes,
    int ArtistId
);