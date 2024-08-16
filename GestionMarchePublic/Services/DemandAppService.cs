using GestionMarchePublic.Contracts;
using GestionMarchePublic.Data.Models;
using GestionMarchePublic.Entities;
using GestionMarchePublic.Permissions;
using GestionMarchePublic.Services.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;

namespace GestionMarchePublic.Services;

[Authorize(GestionMarchePublicPermissions.Demands.Default)]
public class DemandAppService: CrudAppService<Demand, DemandDto, Guid, GetDemandListInput, CreateUpdateDemandDto>, IDemandAppService
{
     public DemandAppService(IDemandRepository repository) : base(repository)
     {
     }
}