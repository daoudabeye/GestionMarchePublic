using AutoMapper;
using GestionMarchePublic.Data.Models;
using GestionMarchePublic.Entities;
using GestionMarchePublic.Pages.Demands;

namespace GestionMarchePublic.ObjectMapping;

public class GestionMarchePublicAutoMapperProfile : Profile
{
    public GestionMarchePublicAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */
        CreateMap<Demand, DemandDto>();
        CreateMap<CreateUpdateDemandDto, Demand>();
        CreateMap<CreateUpdateDemandDto, CreateModalModel.CreateDemandViewModel>().ReverseMap();
    }
}
