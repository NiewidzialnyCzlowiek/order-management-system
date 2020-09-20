using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMSAPI.Dtos.CustomerDtos;
using OMSAPI.Interfaces;
using OMSAPI.Models;

namespace OMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomer customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name="GetCustomer")]
        public ActionResult<CustomerReadFullDto> GetCustomer(int id) 
        {
            var customer = _customerService.Get(id);
            if(customer == null) return NotFound();
            return Ok(_mapper.Map<CustomerReadFullDto>(customer));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerReadDto>> GetAll()
        {
            var customers = _customerService.GetAll();
            return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customers));
        }

        [HttpPost]
        public ActionResult Create(CustomerCreateDto customerCreateDto)
        {
            var customerModel = _mapper.Map<Customer>(customerCreateDto);
            _customerService.Create(customerModel);
            _customerService.SaveChanges();
            var customerReadFullDto = _mapper.Map<CustomerReadFullDto>(customerModel);
            return CreatedAtRoute(nameof(GetCustomer), new {id = customerReadFullDto.Id}, customerReadFullDto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var customerFromDb = _customerService.Get(id);
            if(customerFromDb == null) return NotFound();
            _customerService.Delete(customerFromDb);
            _customerService.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, CustomerUpdateDto customerUpdateDto)
        {
            var customerFromDb = _customerService.Get(id);
            if(customerFromDb == null) return NotFound();
            _mapper.Map(customerUpdateDto, customerFromDb);
            _customerService.Update(customerFromDb);
            _customerService.SaveChanges();
            return NoContent();
        }
    }
}