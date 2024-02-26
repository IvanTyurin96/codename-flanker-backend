using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodenameFlanker.Data.Entities.Configurations;

internal sealed class ImageConfiguration : IEntityTypeConfiguration<Image>
{
	public void Configure(EntityTypeBuilder<Image> builder)
	{
		builder.ToTable(nameof(Image));

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Path)
			.HasColumnType("nvarchar(255)")
			.IsRequired();

		builder.Property(x => x.Description)
			.HasColumnType("nvarchar(255)")
			.IsRequired();
	}
}
