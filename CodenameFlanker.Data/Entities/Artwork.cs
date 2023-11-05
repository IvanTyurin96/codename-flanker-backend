namespace CodenameFlanker.Data.Entities;

public class Artwork
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Thumbnail { get; set; }
	public List<Image> Images { get; set; }
	//public int ArtistId { get; set; }
	public string Description { get; set; }
}
