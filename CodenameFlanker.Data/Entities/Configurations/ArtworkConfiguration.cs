using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodenameFlanker.Data.Entities.Configurations;

public class ArtworkConfiguration : IEntityTypeConfiguration<Artwork>
{
	public void Configure(EntityTypeBuilder<Artwork> builder)
	{
		builder.ToTable(nameof(Artwork));

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.ValueGeneratedNever();

		builder.Property(x => x.Name)
			.HasColumnType("nvarchar(255)")
			.IsRequired();

		builder.Property(x => x.Thumbnail)
			.HasColumnType("nvarchar(255)")
			.IsRequired();

		builder.Property(x => x.ArtistId)
			.HasColumnType("int")
			.IsRequired();

		builder.Property(x => x.Description)
			.HasColumnType("nvarchar(2000)")
			.IsRequired();

		builder.HasMany(x => x.Images)
			.WithOne()
			.HasForeignKey(x => x.ArtworkId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.Artist)
			.WithMany()
			.HasForeignKey(x => x.ArtistId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
