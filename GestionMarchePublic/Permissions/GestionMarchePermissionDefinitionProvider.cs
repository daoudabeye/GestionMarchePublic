
using GestionMarchePublic.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace GestionMarchePublic.Permissions;

public class GestionMarchePermissionDefinitionProvider: PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var permissionGroup = context.AddGroup(GestionMarchePublicPermissions.GroupName, L("Permission:Demand"));

        var booksPermission = permissionGroup.AddPermission(GestionMarchePublicPermissions.Demands.Default, L("Permission:Demands"));
        booksPermission.AddChild(GestionMarchePublicPermissions.Demands.Create, L("Permission:Demands.Create"));
        booksPermission.AddChild(GestionMarchePublicPermissions.Demands.Edit, L("Permission:Demands.Edit"));
        booksPermission.AddChild(GestionMarchePublicPermissions.Demands.Delete, L("Permission:Demands.Delete"));

        var authorsPermission = permissionGroup.AddPermission(
            GestionMarchePublicPermissions.Dossier.Default, L("Permission:Demands:Dossier"));
        authorsPermission.AddChild(
            GestionMarchePublicPermissions.Dossier.Create, L("Permission:Demands:Dossier.Create"));
        authorsPermission.AddChild(
            GestionMarchePublicPermissions.Dossier.Edit, L("Permission:Demands:Dossier.Edit"));
        authorsPermission.AddChild(
            GestionMarchePublicPermissions.Dossier.Delete, L("Permission:Demands:Dossier.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<GestionMarchePublicResource>(name);
    }
}