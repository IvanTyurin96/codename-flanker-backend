namespace CodenameFlanker.Contracts.Artworks.Dto;

public record ArtworkDto
(
    int Id,
    string Name,
    string Thumbnail,
    string ThumbnailBytes,
    int ArtistId,
    string Description
);