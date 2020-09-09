using AutoMapper;
using OMSAPI.Dtos.UnitOfMeasureDtos;
using OMSAPI.Models;

namespace OMSAPI.Profiles
{
    public class UnitOfMeasureProfile : Profile
    {
        public UnitOfMeasureProfile()
        {
            CreateMap<UnitOfMeasure, UnitOfMeasureReadDto>();
            CreateMap<UnitOfMeasure, UnitOfMeasureReadFullDto>();
            CreateMap<UnitOfMeasure, UnitOfMeasureUpdateDto>();
            CreateMap<UnitOfMeasureUpdateDto, UnitOfMeasure>();
            CreateMap<UnitOfMeasureCreateDto, UnitOfMeasure>();
        }
    }
}
