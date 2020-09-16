using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMSAPI.Dtos.AddressDtos;
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
        public ActionResult<AddressReadFullDto> GetAddress(int id) 
        {
            var address = _addressService.Get(id);
            if(address == null) return NotFound();
            return Ok(_mapper.Map<AddressReadFullDto>(address));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AddressReadDto>> GetAll()
        {
            var addresses = _addressService.GetAll();
            return Ok(_mapper.Map<IEnumerable<AddressReadDto>>(addresses));
        }

        [HttpPost]
        public ActionResult Create(AddressCreateDto addressCreateDto)
        {
            var addressModel = _mapper.Map<Address>(addressCreateDto);
            _addressService.Create(addressModel);
            _addressService.SaveChanges();
            var addressReadFullDto = _mapper.Map<AddressReadFullDto>(addressModel); 
            return CreatedAtRoute(nameof(GetAddress), new {id = addressReadFullDto.Id}, addressReadFullDto);
        }

        [HttpGet("forCustomer/{id}")]
        public ActionResult<IEnumerable<AddressReadDto>> GetForCustomer(int id)
        {
            var addressesForCustomer = _addressService.GetAllForCustomer(id);
            return Ok(_mapper.Map<IEnumerable<AddressReadDto>>(addressesForCustomer));
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
        public ActionResult Update(int id, AddressUpdateDto addressUpdateDto)
        {
            var addressFromDb = _addressService.Get(id);
            if(addressFromDb == null) return NotFound();
            _mapper.Map(addressUpdateDto, addressFromDb);
            _addressService.Update(addressFromDb);
            _addressService.SaveChanges();
            return NoContent();
        }
    }
}