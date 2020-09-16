using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMSAPI.Dtos.ItemDtos;
using OMSAPI.Interfaces;
using OMSAPI.Models;

namespace OMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class ItemController : ControllerBase
    {
        private readonly IItem _itemService;
        private readonly IMapper _mapper;
        public ItemController(IItem itemService, Mapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name="GetItem")]
        public ActionResult<ItemReadFullDto> GetItem(int id)
        {
            var item = _itemService.Get(id);
            if(item == null) return NotFound();
            return Ok(_mapper.Map<ItemReadFullDto>(item));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemReadDto>> GetAll()
        {
            var items = _itemService.GetAll();
            return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(items));
        }

        [HttpPost]
        public ActionResult Create(ItemCreateDto itemCreateDto)
        {
            var itemModel = _mapper.Map<Item>(itemCreateDto);
            _itemService.Create(itemModel);
            _itemService.SaveChanges();
            var itemReadFullDto = _mapper.Map<ItemReadFullDto>(itemModel);
            return CreatedAtRoute(nameof(GetItem), new {id = itemReadFullDto.Id}, itemReadFullDto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var itemFromDb = _itemService.Get(id);
            if(itemFromDb == null) return NotFound();
            _itemService.Delete(itemFromDb);
            _itemService.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, ItemUpdateDto itemUpdateDto)
        {
            var itemFromDb = _itemService.Get(id);
            if(itemFromDb == null) return NotFound();
            _mapper.Map(itemUpdateDto, itemFromDb);
            _itemService.Update(itemFromDb);
            _itemService.SaveChanges();
            return NoContent();
        }
    }
}