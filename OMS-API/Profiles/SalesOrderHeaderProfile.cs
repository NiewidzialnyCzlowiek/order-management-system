using AutoMapper;
using OMSAPI.Dtos.SalesOrderHeaderDtos;
using OMSAPI.Models;

namespace OMSAPI.Profiles
{
    public class SalesOrderHeaderProfile : Profile
    {
        public SalesOrderHeaderProfile()
        {
            CreateMap<SalesOrderHeader, SalesOrderHeaderReadDto>();
            CreateMap<SalesOrderHeader, SalesOrderHeaderReadFullDto>();
            CreateMap<SalesOrderHeader, SalesOrderHeaderUpdateDto>();
            CreateMap<SalesOrderHeaderUpdateDto, SalesOrderHeader>();
            CreateMap<SalesOrderHeaderCreateDto, SalesOrderHeader>();
        }
    }
}
