namespace CodenameFlanker.Data.Entities;

public class PatchnoteChange
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Change { get; set; }
	public int PatchnoteId { get; set; }
}
