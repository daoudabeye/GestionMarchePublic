using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper.Internal.Mappers;
using GestionMarchePublic.Contracts;
using GestionMarchePublic.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionMarchePublic.Pages.Demands;

public class EditModalModel : AppPageModel
{
    [BindProperty]
    public CreateDemandViewModel Demand { get; set; }

    //public List<SelectListItem> Authors { get; set; }

    private readonly IDemandAppService _demandAppService;

    public EditModalModel(
        IDemandAppService demandAppService)
    {
        _demandAppService = demandAppService;
    }

    public async Task OnGetAsync()
    {
        Demand = new CreateDemandViewModel();

        // var authorLookup = await _demandAppService.GetAuthorLookupAsync();
        // Authors = authorLookup.Items
        //     .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //     .ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _demandAppService.UpdateAsync(
            Demand.Id,
            ObjectMapper.Map<CreateDemandViewModel, CreateUpdateDemandDto>(Demand)
        );
        return NoContent();
    }

    public class CreateDemandViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        
        //[SelectItems(nameof(Authors))]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(128)]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; } //= BookType.Undefined;

        [Required]
        [DataType(DataType.Date)]
        public DateTime SubmissionDate { get; set; } = DateTime.Now;

        [Required]
        public float Amount { get; set; }
        
        // Relation avec l'entité User
        public Guid? RequestBy { get; set; }

        // Relation avec l'entité User
        public Guid? ValidateBy { get; set; }
    }
}