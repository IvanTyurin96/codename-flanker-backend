namespace CodenameFlanker.Contracts.Artworks.Dto;

public record ListedArtworkDto
(
    int Id,
    string Name,
    string ThumbnailBytes,
    int ArtistId
);