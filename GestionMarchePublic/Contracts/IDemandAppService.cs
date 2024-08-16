using GestionMarchePublic.Data.Models;
using GestionMarchePublic.Services.Dtos;
using Volo.Abp.Application.Services;

namespace GestionMarchePublic.Contracts;

public interface IDemandAppService: ICrudAppService< 
    DemandDto, 
    Guid, 
    GetDemandListInput, CreateUpdateDemandDto>
{
    
}