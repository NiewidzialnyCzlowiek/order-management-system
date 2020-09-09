using AutoMapper;
using OMSAPI.Dtos.CustomerDtos;
using OMSAPI.Models;

namespace OMSAPI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<Customer, CustomerReadFullDto>();
            CreateMap<Customer, CustomerUpdateDto>();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<CustomerCreateDto, Customer>();
        }
    }
}
