namespace CodenameFlanker.Data.Entities;

public sealed class Image
{
	public int Id { get; set; }
	public string Path { get; set; }
	public string Description { get; set; }
	public int ArtworkId { get; set; }
}
