using GestionMarchePublic.Localization;
using GestionMarchePublic.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace GestionMarchePublic.Menus;

public class GestionMarchePublicMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<GestionMarchePublicResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                GestionMarchePublicMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
        
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                GestionMarchePublicMenus.Dashboard,
                l["Menu:Dashboard"],
                "/Dashboard",
                icon: "ni ni-growth-fill",
                order: 1
            )
        );

        if (GestionMarchePublicModule.IsMultiTenant)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Demands",
                l["Menu:Demands"],
                icon: "fas fa-folder"
            ).AddItem(
                new ApplicationMenuItem(
                    GestionMarchePublicMenus.Form,
                    l["Menu:Form"],
                    "/Demands/Form"
                    ).RequirePermissions(GestionMarchePublicPermissions.Demands.Create)
            ).AddItem(
                new ApplicationMenuItem(
                    "Manage.Demands",
                    l["Menu:Demands"],
                    url: "/Demands"
                ).RequirePermissions(GestionMarchePublicPermissions.Demands.Default)
            ).AddItem( // ADDED THE NEW "AUTHORS" MENU ITEM UNDER THE "BOOK STORE" MENU
                new ApplicationMenuItem(
                    "Manage.Demands.Cards",
                    l["Menu:Demands:Cards"],
                    url: "/Demands/Cards"
                ).RequirePermissions(GestionMarchePublicPermissions.Dossier.Default)
            ));

        return Task.CompletedTask;
    }
}
