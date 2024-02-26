using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodenameFlanker.Data.Entities.Configurations;

internal sealed class ScreenshotConfiguration : IEntityTypeConfiguration<Screenshot>
{
	public void Configure(EntityTypeBuilder<Screenshot> builder)
	{
		builder.ToTable(nameof(Screenshot));

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Path)
			.HasColumnType("nvarchar(255)")
			.IsRequired();
		builder.Property(x => x.Thumbnail)
			.HasColumnType("nvarchar(255)")
			.IsRequired();
	}
}
