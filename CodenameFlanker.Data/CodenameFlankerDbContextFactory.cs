using CodenameFlanker.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodenameFlanker.Data;

public class CodenameFlankerDbContextFactory : IDesignTimeDbContextFactory<CodenameFlankerDbContext>
{
	public CodenameFlankerDbContext CreateDbContext(string[] args)
	{
		string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "migrationSettings.json");
		string connectionString = JsonParser.GetConnectionString("CodenameFlanker", jsonPath);

		var optionsBuilder = new DbContextOptionsBuilder<CodenameFlankerDbContext>();
		optionsBuilder.UseSqlServer(connectionString);
		return new CodenameFlankerDbContext(optionsBuilder.Options);
	}
}
