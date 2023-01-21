using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CbIntegrator.DbContexts
{
	public class CbIntegratorDbContextFactory : IDesignTimeDbContextFactory<CbIntegratorDbContext>
	{
		//Question::Нормально ли прокидывать сюда connection из Bussynes
		public CbIntegratorDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<CbIntegratorDbContext>();
			optionsBuilder.UseMySql("Server=127.0.0.1;Database=integrator;port=3306;User Id=root;password=Olegka_2003",
				new MySqlServerVersion(new Version(8,0,30)));
				
			return new CbIntegratorDbContext(optionsBuilder.Options);
		}
	}
}