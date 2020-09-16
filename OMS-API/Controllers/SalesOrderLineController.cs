using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMSAPI.Dtos.SalesOrderLineDtos;
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
        public ActionResult<SalesOrderLineReadFullDto> GetSalesOrderLine(int id) 
        {
            var salesOrderLine = _salesOrderLineService.Get(id);
            if(salesOrderLine == null) return NotFound();
            return Ok(_mapper.Map<SalesOrderLineReadFullDto>(salesOrderLine));
        }
        [HttpGet("forHeader/{id}")]
        public ActionResult<IEnumerable<SalesOrderLineReadDto>> GetAllForSalesOrderHeader(int id)
        {
            var salesOrderLines = _salesOrderLineService.GetAllForSalesOrder(id);
            return Ok(_mapper.Map<IEnumerable<SalesOrderLineReadDto>>(salesOrderLines));
        }

        [HttpGet]
        public ActionResult<IEnumerable<SalesOrderLineReadDto>> GetAll()
        {
            var salesOrderLines = _salesOrderLineService.GetAll();
            return Ok(_mapper.Map<IEnumerable<SalesOrderLineReadDto>>(salesOrderLines));
        }

        [HttpPost]
        public ActionResult Create(SalesOrderLineCreateDto salesOrderLineCreateDto)
        {
            var salesOrderLineModel = _mapper.Map<SalesOrderLine>(salesOrderLineCreateDto);
            _salesOrderLineService.Create(salesOrderLineModel);
            _salesOrderLineService.SaveChanges();
            var salesOrderLineReadFullDto = _mapper.Map<SalesOrderLineReadFullDto>(salesOrderLineModel);
            return CreatedAtRoute(nameof(SalesOrderLine), new {id = salesOrderLineReadFullDto.Id}, salesOrderLineReadFullDto);
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

        [HttpPut("{id}")]
        public ActionResult Update(int id, SalesOrderLineUpdateDto salesOrderLineUpdateDto)
        {
            var salesOrderLineFromDb = _salesOrderLineService.Get(id);
            if(salesOrderLineFromDb == null) return NotFound();
            _mapper.Map(salesOrderLineUpdateDto, salesOrderLineFromDb);
            _salesOrderLineService.Update(salesOrderLineFromDb);
            _salesOrderLineService.SaveChanges();
            return NoContent();
        }
    }
}