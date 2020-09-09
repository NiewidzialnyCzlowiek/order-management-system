using AutoMapper;
using OMSAPI.Dtos.SalesOrderLineDtos;
using OMSAPI.Models;

namespace OMSAPI.Profiles
{
    public class SalesOrderLineProfile : Profile
    {
        public SalesOrderLineProfile()
        {
            CreateMap<SalesOrderLine, SalesOrderLineReadDto>();
            CreateMap<SalesOrderLine, SalesOrderLineReadFullDto>();
            CreateMap<SalesOrderLine, SalesOrderLineUpdateDto>();
            CreateMap<SalesOrderLineUpdateDto, SalesOrderLine>();
            CreateMap<SalesOrderLineCreateDto, SalesOrderLine>();
        }
    }
}
