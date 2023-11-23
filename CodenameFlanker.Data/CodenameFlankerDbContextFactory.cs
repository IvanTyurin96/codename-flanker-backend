using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodenameFlanker.Data;

public class CodenameFlankerDbContextFactory : IDesignTimeDbContextFactory<CodenameFlankerDbContext>
{
	public CodenameFlankerDbContext CreateDbContext(string[] args)
	{
		string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "migrationSettings.json");

		var optionsBuilder = new DbContextOptionsBuilder<CodenameFlankerDbContext>();

		string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "CodenameFlanker.db");
		optionsBuilder.UseSqlite($"Filename={path}");
		return new CodenameFlankerDbContext(optionsBuilder.Options);
	}
}
