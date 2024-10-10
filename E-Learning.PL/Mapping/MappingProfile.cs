using AutoMapper;
using E_Learning.DAL.Models;
using E_Learning.PL.Areas.Dashboard.ViewModels;

namespace E_Learning.PL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ServiceFormVM, Service>();
            CreateMap<Service,ShowServicesVM>();
            CreateMap<Service,ServiceDetailsVM>();


        }
    }
}
