using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodenameFlanker.Data.Entities.Configurations;

public class PatchnoteConfiguration : IEntityTypeConfiguration<Patchnote>
{
	public void Configure(EntityTypeBuilder<Patchnote> builder)
	{
		builder.ToTable(nameof(Patchnote));

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.ValueGeneratedNever();

		builder.Property(x => x.Version)
			.HasColumnType("nvarchar(255)")
			.IsRequired();

		builder.HasMany(x => x.PatchnoteChanges)
			.WithOne()
			.HasForeignKey(x => x.PatchnoteId);
	}
}
