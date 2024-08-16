using EasyAbp.FileManagement.EntityFrameworkCore;
using GestionMarchePublic.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace GestionMarchePublic.Data;

public class GestionMarchePublicDbContext : AbpDbContext<GestionMarchePublicDbContext>
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<Demand> Demands { get; set; }
    public GestionMarchePublicDbContext(DbContextOptions<GestionMarchePublicDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
        
        // builder.ConfigureFileManagement();

        /* Configure your own entities here */

        builder.Entity<Demand>(b =>
        {
            //Configure table & schema name
            b.ToTable("Demands");
            b.ConfigureByConvention();
            
            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        
        
    }
}
