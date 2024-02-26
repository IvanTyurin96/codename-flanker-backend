using CodenameFlanker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class PatchnoteChangeConfiguration : IEntityTypeConfiguration<PatchnoteChange>
{
	public void Configure(EntityTypeBuilder<PatchnoteChange> builder)
	{
		builder.ToTable(nameof(PatchnoteChange));

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Name)
			.HasColumnType("nvarchar(255)")
			.IsRequired();

		builder.Property(x => x.Change)
			.HasColumnType("nvarchar(2000)")
			.IsRequired();

		builder.Property(x => x.PatchnoteId)
			.HasColumnType("int")
			.IsRequired();
	}
}
