namespace CodenameFlanker.Data.Entities;

public sealed class Patchnote
{
	public int Id { get; set; }
	public string Version { get; set; }
	public IEnumerable<PatchnoteChange> PatchnoteChanges { get; set; }
}
