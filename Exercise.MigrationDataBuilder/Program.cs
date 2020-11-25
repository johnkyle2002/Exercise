using Exercise.Repository.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Exercise.MigrationDataBuilder
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json");

            var configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<PaymentDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PaymentDBContext"), b => b.MigrationsAssembly("Exercise.MigrationDataBuilder"));
        }
    }
    public class B2BDbContextContextFactory : IDesignTimeDbContextFactory<PaymentDBContext>
    {
        public PaymentDBContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<PaymentDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PaymentDBContext"), b => b.MigrationsAssembly("Exercise.MigrationDataBuilder"));

            return new PaymentDBContext(optionsBuilder.Options);
        }
    }
}
