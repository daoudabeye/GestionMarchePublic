using IkawaariSaaS.Theme.Dashlite.UI;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace GestionMarchePublic.Services;

[Dependency(ReplaceServices = true)]
public class MarcheBrandingProvider: DefaultBrandingProvider
{
    public override string AppName => "DGMP";

    public override string LogoUrl => "/images/logo.png";

    //public override string LogoUrl2X => "/images/logo.png";

    //public override string LogoSmall => "/image/logo.png";
}

