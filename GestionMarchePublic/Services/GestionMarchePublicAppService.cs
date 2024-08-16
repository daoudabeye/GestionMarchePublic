using GestionMarchePublic.Localization;
using Volo.Abp.Application.Services;

namespace GestionMarchePublic.Services;

/* Inherit your application services from this class. */
public abstract class GestionMarchePublicAppService : ApplicationService
{
    protected GestionMarchePublicAppService()
    {
        LocalizationResource = typeof(GestionMarchePublicResource);
    }
}