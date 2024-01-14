using AutoMapper;
using SignalR.DTO.Dtos.AboutDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Mapping
{
    public class GeneralMapping: Profile
    {

        public GeneralMapping()
        {
            CreateMap<CreateAboutDto,About>().ReverseMap();
            CreateMap<UpdateAboutDto,About>().ReverseMap();
            CreateMap<ResultAboutDto,About>().ReverseMap();
        }
    }
}
