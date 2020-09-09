using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<Item> GetItem(int id)
        {
            var item = _itemService.Get(id);
            if(item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetAll()
        {
            var items = _itemService.GetAll();
            return Ok(items);
        }

        [HttpPost]
        public ActionResult Create(Item item)
        {
            _itemService.Create(item);
            _itemService.SaveChanges();
            return CreatedAtRoute(nameof(GetItem), new {id = item.Id}, item);
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
    }
}