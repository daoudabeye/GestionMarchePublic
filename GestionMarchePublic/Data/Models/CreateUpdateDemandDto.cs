using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;

namespace GestionMarchePublic.Data.Models;

public class CreateUpdateDemandDto: FullAuditedEntityDto<Guid>
{
    [Required]
    [StringLength(128)]
    public required string Title { get; set; }
    
    [Required]
    [StringLength(256)]
    public required string Description { get; set; }
    
    [Required]
    public decimal Amount { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime SubmissionDate { get; set; }
    
    [Required]
    [StringLength(1)]
    public required string Status { get; set; }
    
    // Relation avec l'entité User
    public Guid? RequestBy { get; set; }

    // Relation avec l'entité User
    public Guid? ValidateBy { get; set; }
}