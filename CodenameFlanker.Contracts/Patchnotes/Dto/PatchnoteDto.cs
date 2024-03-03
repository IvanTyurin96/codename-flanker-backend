using CodenameFlanker.Contracts.PatchnoteChanges.Dto;
using System.Collections.Generic;

namespace CodenameFlanker.Contracts.Patchnotes.Dto;

public record PatchnoteDto
(
	int Id,
	string Version,
	IReadOnlyCollection<PatchnoteChangeDto> PatchnoteChanges
);
