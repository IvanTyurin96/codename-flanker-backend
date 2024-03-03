namespace CodenameFlanker.Data.Entities;

public sealed class Artwork
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Thumbnail { get; set; }
	public IEnumerable<Image> Images { get; set; }
	public int ArtistId { get; set; }
	public Artist Artist { get; set; }
	public string Description { get; set; }
}
