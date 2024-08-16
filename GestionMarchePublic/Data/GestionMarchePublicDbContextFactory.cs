using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GestionMarchePublic.Data;

public class GestionMarchePublicDbContextFactory : IDesignTimeDbContextFactory<GestionMarchePublicDbContext>
{
    public GestionMarchePublicDbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<GestionMarchePublicDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));

        return new GestionMarchePublicDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
