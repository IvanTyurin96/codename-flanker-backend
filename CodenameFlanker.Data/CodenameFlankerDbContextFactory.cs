using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodenameFlanker.Data;

public class CodenameFlankerDbContextFactory : IDesignTimeDbContextFactory<CodenameFlankerDbContext>
{
	public CodenameFlankerDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<CodenameFlankerDbContext>();
		optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=CodenameFlanker;Integrated Security=SSPI;");
		return new CodenameFlankerDbContext(optionsBuilder.Options);
	}
}
