namespace CodenameFlanker.Data.Entities;

public class Patchnote
{
	public int Id { get; set; }
	public string Version { get; set; }
	public List<PatchnoteChange> PatchnoteChanges { get; set; }
}
