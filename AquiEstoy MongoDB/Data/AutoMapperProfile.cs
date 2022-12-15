using AutoMapper;
using AquiEstoy_MongoDB.Data.Entities;
using AquiEstoy_MongoDB.Models;

namespace AQUI_ESTOY.Data
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<UserEntity, UserModel>()
                //.ForMember( des => des.Phone, opt => opt.MapFrom(src => src.Phone + "#" + src.Name ))
                .ReverseMap();
            this.CreateMap<PetEntity, PetModel>()
                .ReverseMap();
            this.CreateMap<LostPetPostEntity, LostPetPostModel>()
                .ReverseMap();
            this.CreateMap<FoundPetPostEntity, FoundPetPostModel>()
                .ReverseMap();
        }
    }
}
