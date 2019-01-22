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
    public class AddressController : ControllerBase
    {
        private IAddress _addressService;
        public AddressController(IAddress addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("{addressId}")]
        public ActionResult<Address> Get(int addressId) 
        {
            return _addressService.Get(addressId);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Address>> GetAll()
        {
            return _addressService.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult<DatabaseOperationStatus> Post(Address address)
        {
            return _addressService.Insert(address);
        }
        [HttpGet("forCustomer/{customerId}")]
        public ActionResult<IEnumerable<Address>> GetForCustomer(int customerId)
        {
            return _addressService.GetAllForCustomer(customerId).ToArray();
        }

        [HttpPost("delete")]
        public ActionResult<DatabaseOperationStatus> Delete(DeletionRequest request) {
            return _addressService.Delete(request.IntPk, request.Cascade);
        }
    }
}