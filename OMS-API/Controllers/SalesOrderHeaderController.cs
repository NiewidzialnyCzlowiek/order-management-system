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
    public class SalesOrderHeaderController : ControllerBase
    {
        private readonly ISalesOrderHeader _salesOrderHeaderService;
        private readonly IMapper _mapper;
        public SalesOrderHeaderController(ISalesOrderHeader salesOrderHeaderService, Mapper mapper)
        {
            _salesOrderHeaderService = salesOrderHeaderService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name="GetSalesOrderHeader")]
        public ActionResult<SalesOrderHeader> GetSalesOrderHeader(int id) 
        {
            var salesOrderHeader = _salesOrderHeaderService.Get(id);
            if(salesOrderHeader == null) return NotFound();
            return Ok(salesOrderHeader);
        }

        [HttpGet]
        public ActionResult<IEnumerable<SalesOrderHeader>> GetAll()
        {
            var salesOrderHeaders = _salesOrderHeaderService.GetAll();
            return Ok(salesOrderHeaders);
        }

        [HttpPost]
        public ActionResult Create(SalesOrderHeader salesOrderHeader)
        {
            _salesOrderHeaderService.Create(salesOrderHeader);
            _salesOrderHeaderService.SaveChanges();
            return CreatedAtRoute(nameof(GetSalesOrderHeader), new {id = salesOrderHeader.Id}, salesOrderHeader);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var headerFromDb = _salesOrderHeaderService.Get(id);
            if(headerFromDb == null) return NotFound();
            _salesOrderHeaderService.Delete(headerFromDb);
            _salesOrderHeaderService.SaveChanges();
            return NoContent();
        }

        [HttpGet("profit/{id}")]
        public ActionResult<SalesOrderHeader> UpdateProfit(int id) {
            var ok = _salesOrderHeaderService.UpdateProfit(id);
            var orderHeader = _salesOrderHeaderService.Get(id);
            if (!ok) {
                orderHeader.Profit = 0.0M;
            }
            return orderHeader;
        }
    }
}