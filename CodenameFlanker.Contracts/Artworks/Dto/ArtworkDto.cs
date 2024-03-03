using CodenameFlanker.Contracts.Artists.Dto;
using CodenameFlanker.Contracts.Images.Dto;
using System.Collections.Generic;

namespace CodenameFlanker.Contracts.Artworks.Dto;

public record ArtworkDto
(
	int Id,
	string Name,
	IReadOnlyCollection<ImageDto> Images,
	ArtistDto Artist,
	string Description
);