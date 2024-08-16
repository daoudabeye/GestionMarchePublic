using Microsoft.AspNetCore.Authorization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace GestionMarchePublic.Pages;

[Authorize]
public class IndexModel : AbpPageModel
{
    
}