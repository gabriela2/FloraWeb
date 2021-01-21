using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Flower,FlowerToReturnDto>()
                .ForMember(d => d.FlowerCategory, o => o.MapFrom( s => s.FlowerCategory.Name))
                .ForMember(d => d.FlowerType, o => o.MapFrom( s => s.FlowerType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<FlowerUrlResolver>());
        }
    }
}