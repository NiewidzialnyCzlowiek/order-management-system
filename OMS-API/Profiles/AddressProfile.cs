using AutoMapper;
using OMSAPI.Dtos.AddressDtos;
using OMSAPI.Models;

namespace OMSAPI.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressReadDto>();
            CreateMap<Address, AddressReadFullDto>();
            CreateMap<Address, AddressUpdateDto>();
            CreateMap<AddressUpdateDto, Address>();
            CreateMap<AddressCreateDto, Address>();
        }
    }
}
