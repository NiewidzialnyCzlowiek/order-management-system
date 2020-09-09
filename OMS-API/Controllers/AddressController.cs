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
    public class AddressController : ControllerBase
    {
        private readonly IAddress _addressService;
        private readonly IMapper _mapper;

        public AddressController(IAddress addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name="GetAddress")]
        public ActionResult<Address> GetAddress(int id) 
        {
            var address = _addressService.Get(id);
            if(address == null) return NotFound();
            return Ok(address);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Address>> GetAll()
        {
            return _addressService.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult Create(Address address)
        {
            _addressService.Create(address);
            _addressService.SaveChanges();
            return CreatedAtRoute(nameof(GetAddress), new {id = address.Id}, address);
        }
        [HttpGet("forCustomer/{id}")]
        public ActionResult<IEnumerable<Address>> GetForCustomer(int id)
        {
            var addressesForCustomer = _addressService.GetAllForCustomer(id);
            return Ok(addressesForCustomer);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            var addressFromDb = _addressService.Get(id);
            if(addressFromDb == null) return NotFound();
            _addressService.Delete(addressFromDb);
            _addressService.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Address address)
        {
            var addressFromDb = _addressService.Get(id);
            if(addressFromDb == null) return NotFound();
            _addressService.Update(address);
            _addressService.SaveChanges();
            return NoContent();
        }
    }
}