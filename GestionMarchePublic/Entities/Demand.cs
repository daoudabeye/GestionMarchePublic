using Volo.Abp.Domain.Entities.Auditing;

namespace GestionMarchePublic.Entities;

public class Demand: FullAuditedEntity<Guid>
{
    public required string UniqueId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime SubmissionDate { get; set; }
    public required string Status { get; set; }
    public Guid? RequestBy { get; set; }
    public Guid? ValidateBy { get; set; }
}