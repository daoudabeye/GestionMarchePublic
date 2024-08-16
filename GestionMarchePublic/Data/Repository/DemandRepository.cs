using GestionMarchePublic.Contracts;
using GestionMarchePublic.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GestionMarchePublic.Data.Repository;

public class DemandRepository: EfCoreRepository<GestionMarchePublicDbContext, Demand, Guid>, IDemandRepository
{
    public DemandRepository(IDbContextProvider<GestionMarchePublicDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}