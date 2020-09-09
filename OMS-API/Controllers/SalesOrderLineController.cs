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
    public class SalesOrderLineController : ControllerBase
    {
        private ISalesOrderLine _salesOrderLineService;
        private readonly IMapper _mapper;
        public SalesOrderLineController(ISalesOrderLine salesOrderLineService, Mapper mapper)
        {
            _salesOrderLineService = salesOrderLineService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name="SalesOrderLine")]
        public ActionResult<SalesOrderLine> GetSalesOrderLine(int id) 
        {
            var salesOrderLine = _salesOrderLineService.Get(id);
            if(salesOrderLine == null) return NotFound();
            return Ok(salesOrderLine);
        }
        [HttpGet("forHeader/{id}")]
        public ActionResult<IEnumerable<SalesOrderLine>> GetAllForSalesOrderHeader(int id)
        {
            var salesOrderLines = _salesOrderLineService.GetAllForSalesOrder(id);
            return Ok(salesOrderLines);
        }

        [HttpGet]
        public ActionResult<IEnumerable<SalesOrderLine>> GetAll()
        {
            var salesOrderLines = _salesOrderLineService.GetAll();
            return Ok(salesOrderLines);
        }

        [HttpPost]
        public ActionResult Create(SalesOrderLine orderLine)
        {
            _salesOrderLineService.Create(orderLine);
            _salesOrderLineService.SaveChanges();
            return CreatedAtRoute(nameof(SalesOrderLine), new {id = orderLine.Id}, orderLine);
        }    
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var lineFromDb = _salesOrderLineService.Get(id);
            if(lineFromDb == null) return NotFound();
            _salesOrderLineService.Delete(lineFromDb);
            _salesOrderLineService.SaveChanges();
            return NoContent();
        }    
    }
}