using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMSAPI.Dtos.SalesOrderHeaderDtos;
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
        public SalesOrderHeaderController(ISalesOrderHeader salesOrderHeaderService, IMapper mapper)
        {
            _salesOrderHeaderService = salesOrderHeaderService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name="GetSalesOrderHeader")]
        public ActionResult<SalesOrderHeaderReadFullDto> GetSalesOrderHeader(int id) 
        {
            var salesOrderHeader = _salesOrderHeaderService.Get(id);
            if(salesOrderHeader == null) return NotFound();
            return Ok(_mapper.Map<SalesOrderHeaderReadFullDto>(salesOrderHeader));
        }

        [HttpGet]
        public ActionResult<IEnumerable<SalesOrderHeaderReadDto>> GetAll()
        {
            var salesOrderHeaders = _salesOrderHeaderService.GetAll();
            return Ok(_mapper.Map<IEnumerable<SalesOrderHeaderReadDto>>(salesOrderHeaders));
        }

        [HttpPost]
        public ActionResult Create(SalesOrderHeaderCreateDto salesOrderHeaderCreateDto)
        {
            var salesOrderHeaderModel = _mapper.Map<SalesOrderHeader>(salesOrderHeaderCreateDto);
            _salesOrderHeaderService.Create(salesOrderHeaderModel);
            _salesOrderHeaderService.SaveChanges();
            var salesOrderHeaderReadFullDto = _mapper.Map<SalesOrderHeaderReadFullDto>(salesOrderHeaderModel);
            return CreatedAtRoute(nameof(GetSalesOrderHeader), new {id = salesOrderHeaderReadFullDto.Id}, salesOrderHeaderReadFullDto);
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

        [HttpPut("{id}")]
        public ActionResult Update(int id, SalesOrderHeaderUpdateDto salesOrderHeaderUpdateDto)
        {
            var salesOrderHeaderFromDb = _salesOrderHeaderService.Get(id);
            if(salesOrderHeaderFromDb == null) return NotFound();
            _mapper.Map(salesOrderHeaderUpdateDto, salesOrderHeaderFromDb);
            _salesOrderHeaderService.Update(salesOrderHeaderFromDb);
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