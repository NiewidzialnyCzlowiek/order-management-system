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
        public ActionResult<Customer> GetCustomer(int id) 
        {
            var customer = _customerService.Get(id);
            if(customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _customerService.Create(customer);
            _customerService.SaveChanges();
            return CreatedAtRoute(nameof(GetCustomer), new {id = customer.Id}, customer);
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
    }
}