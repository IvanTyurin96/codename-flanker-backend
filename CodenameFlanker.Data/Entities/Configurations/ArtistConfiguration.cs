using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodenameFlanker.Data.Entities.Configurations;

internal sealed class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
	public void Configure(EntityTypeBuilder<Artist> builder)
	{
		builder.ToTable(nameof(Artist));

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.ValueGeneratedNever();

		builder.Property(x => x.Name)
			.HasColumnType("nvarchar(255)")
			.IsRequired();

		builder.Property(x => x.Icon)
			.HasColumnType("nvarchar(255)")
			.IsRequired();

		builder.Property(x => x.Role)
			.HasColumnType("nvarchar(255)")
			.IsRequired();
	}
}
