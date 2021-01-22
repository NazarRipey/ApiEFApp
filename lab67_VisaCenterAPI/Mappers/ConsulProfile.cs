using AutoMapper;
using lab67_VisaCenterAPI.ViewModels;
using lab67_VisaCenterDAL.Entities;

namespace lab67_VisaCenterAPI.Mappers
{
    public class ConsulProfile : Profile
    {
        public ConsulProfile()
        {
            CreateMap<Consul, ConsulViewModel>().ReverseMap();

            CreateMap<Consul, ConsulViewModel>()
                .ForMember(cv => cv.Name, c => c.MapFrom(x => x.Name))
                .ForMember(cv => cv.CountryName, c => c.MapFrom(c => c.Country.Name));
        }
    }
}
