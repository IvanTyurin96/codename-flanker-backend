namespace CodenameFlanker.Contracts.PatchnoteChanges.Dto;

public record PatchnoteChangeDto
(
	int Id,
	string Name,
	string Change,
	int PatchnoteId
);
