using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OMSAPI.Interfaces;
using OMSAPI.Models;

namespace OMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class ItemController : ControllerBase
    {
        private IItem _itemService;
        public ItemController(IItem itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{itemId}")]
        public ActionResult<Item> Get(int itemId) 
        {
            return _itemService.Get(itemId);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetAll()
        {
            return _itemService.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult<DatabaseOperationStatus> Post(Item item)
        {
            return _itemService.Insert(item);
        }    }
}