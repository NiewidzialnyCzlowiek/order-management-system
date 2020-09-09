using AutoMapper;
using OMSAPI.Dtos.ItemDtos;
using OMSAPI.Models;

namespace OMSAPI.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemReadDto>();
            CreateMap<Item, ItemReadFullDto>();
            CreateMap<Item, ItemUpdateDto>();
            CreateMap<ItemUpdateDto, Item>();
            CreateMap<ItemCreateDto, Item>();
        }
    }
}
