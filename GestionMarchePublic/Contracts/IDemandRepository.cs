using GestionMarchePublic.Entities;
using Volo.Abp.Domain.Repositories;

namespace GestionMarchePublic.Contracts;

public interface IDemandRepository: IRepository<Demand, Guid>
{
    
}