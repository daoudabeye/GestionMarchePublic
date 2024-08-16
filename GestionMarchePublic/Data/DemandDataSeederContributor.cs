using GestionMarchePublic.Contracts;
using GestionMarchePublic.Entities;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace GestionMarchePublic.Data;

public class DemandDataSeederContributor: IDataSeedContributor, ITransientDependency
{
    private readonly IDemandRepository _demandeRepository;
    private readonly IdentityUserManager _identityUserManager;
    private readonly IdentityRoleManager _roleManager;
    private readonly IPermissionDataSeeder _permissionDataSeeder;
    private readonly IPermissionDefinitionManager _permissionDefinitionManager;
    
    public DemandDataSeederContributor(IDemandRepository demandeRepository, IdentityUserManager identityUserManager,
        IdentityRoleManager roleManager, IPermissionDataSeeder permissionDataSeeder, IPermissionDefinitionManager permissionDefinitionManager)
    {
        _demandeRepository = demandeRepository;
        _identityUserManager = identityUserManager;
        _roleManager = roleManager;
        _permissionDataSeeder = permissionDataSeeder;
        _permissionDefinitionManager = permissionDefinitionManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _demandeRepository.GetCountAsync() > 0)
        {
            return;
        }
        await _demandeRepository.InsertAsync(
        new Demand()
        {
            UniqueId = "DC/2024/0001",
            Title = "Financement Projet",
            Description = "Demande de financement du projet rural",
            SubmissionDate = DateTime.Now,
            Amount = 1000000m,
            Status = "N",
            RequestBy = Guid.NewGuid(),
            ValidateBy = Guid.NewGuid()
        }, autoSave: true);
        
        await _demandeRepository.InsertAsync(
            new Demand()
            {
                UniqueId = "DC/2024/0002",
                Title = "Infra Basket",
                Description = "Demande de financement",
                SubmissionDate = DateTime.Now,
                Amount = 1000000m,
                Status = "N",
                RequestBy = Guid.NewGuid(),
                ValidateBy = Guid.NewGuid()
            }, autoSave: true);
        
        
        var roleDg = new Volo.Abp.Identity.IdentityRole(
            Guid.NewGuid(), 
            "Directeur", context.TenantId
        )
        {
            IsStatic = true,
            IsPublic = true
        };
            
        var roleAgent = new Volo.Abp.Identity.IdentityRole(
            Guid.NewGuid(), 
            "Agent", context.TenantId
        )
        {
            IsStatic = true,
            IsPublic = true
        };
            
        (await _roleManager.CreateAsync(roleDg)).CheckErrors();
        (await _roleManager.CreateAsync(roleAgent)).CheckErrors();

        var directeur = new IdentityUser(Guid.NewGuid(), "directeur", "directeur@abp.io");
        await _identityUserManager.CreateAsync(directeur, "1q2w3E*");
        await _identityUserManager.AddToRoleAsync(directeur, "Directeur");
        
        var agent = new IdentityUser(Guid.NewGuid(), "agent", "agent@abp.io");
        await _identityUserManager.CreateAsync(agent, "1q2w3E*");
        await _identityUserManager.AddToRoleAsync(agent, "Agent");
        
        //Add Permissions
        var permissionNames = (await _permissionDefinitionManager.GetPermissionsAsync())
            .Where(p => p.Name.Contains("Demand"))
            .Select(p => p.Name)
            .ToArray();
        await _permissionDataSeeder.SeedAsync(
            RolePermissionValueProvider.ProviderName,
            "Directeur",
            permissionNames,
            context?.TenantId
        );
        
        //Add Permissions
        var agentNames = (await _permissionDefinitionManager.GetPermissionsAsync())
            .Where(p => p.Name.Contains("Demands.Create")  || p.Name.Contains("Demands.Edit"))
            .Select(p => p.Name)
            .ToArray();
        await _permissionDataSeeder.SeedAsync(
            RolePermissionValueProvider.ProviderName,
            "Agent",
            agentNames,
            context?.TenantId
        );
    }
}