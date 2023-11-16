using CodenameFlanker.Contracts.Artists.Dto;
using CodenameFlanker.Contracts.Images.Dto;

namespace CodenameFlanker.Contracts.Artworks.Dto;

public record ArtworkDto
(
	int Id,
	string Name,
	int ArtistId,
	string Description,
	List<ImageDto> Images,
	ArtistDto Artist
);