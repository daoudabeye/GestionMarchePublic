using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace GestionMarchePublic.Data;

public class GestionMarchePublicEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public GestionMarchePublicEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the GestionMarchePublicDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<GestionMarchePublicDbContext>()
            .Database
            .MigrateAsync();
    }
}
