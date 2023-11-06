using CodenameFlanker.Data.Entities;
using CodenameFlanker.Data.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CodenameFlanker.Data;

public class CodenameFlankerDbContext : DbContext
{
	public DbSet<Artwork> Artworks { get; set; }
	public DbSet<Patchnote> Patchnotes { get; set; }

	public CodenameFlankerDbContext(DbContextOptions<CodenameFlankerDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new ArtistConfiguration());
		modelBuilder.ApplyConfiguration(new ArtworkConfiguration());
		modelBuilder.ApplyConfiguration(new ImageConfiguration());
		modelBuilder.ApplyConfiguration(new PatchnoteConfiguration());
		modelBuilder.ApplyConfiguration(new PatchnoteChangeConfiguration());
	}
}
