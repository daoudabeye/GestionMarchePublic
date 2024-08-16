using Volo.Abp.Application.Dtos;

namespace GestionMarchePublic.Services.Dtos;

public class GetDemandListInput: PagedAndSortedResultRequestDto
{
    public Guid? UserId { get; set; }
}