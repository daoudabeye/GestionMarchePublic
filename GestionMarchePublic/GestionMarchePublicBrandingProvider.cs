using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace GestionMarchePublic;

[Dependency(ReplaceServices = true)]
public class GestionMarchePublicBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "GestionMarchePublic";
}
