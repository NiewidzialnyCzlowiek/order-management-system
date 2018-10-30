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
    public class CustomerController : ControllerBase
    {
        private ICustomer _customerService;
        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{customerNo}")]
        public ActionResult<Customer> Get(string customerNo) 
        {
            return _customerService.Get(customerNo);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return _customerService.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult<bool> Post(Customer customer)
        {
            _customerService.Insert(customer);
            return true;
        }
    }
}