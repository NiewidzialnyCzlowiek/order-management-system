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

        [HttpGet("{customerId}")]
        public ActionResult<Customer> Get(int customerId) 
        {
            return _customerService.Get(customerId);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            return _customerService.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult<DatabaseOperationStatus> Post(Customer customer)
        {
            return _customerService.Insert(customer);
        }

        [HttpPost("delete")]
        public ActionResult<DatabaseOperationStatus> Post(DeletionRequest request)
        {
            return _customerService.Delete(request.IntPk);
        }
    }
}