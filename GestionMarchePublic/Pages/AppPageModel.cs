using GestionMarchePublic.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace GestionMarchePublic.Pages;

public class AppPageModel: AbpPageModel
{
    public AppPageModel()
    {
        LocalizationResourceType = typeof(GestionMarchePublicResource);

    }
}