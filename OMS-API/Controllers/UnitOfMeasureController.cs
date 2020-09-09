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
    public class UnitOfMeasureController : ControllerBase
    {
        private readonly IUnitOfMeasure _unitOfMeasureService;
        private readonly IMapper _mapper;
        public UnitOfMeasureController(IUnitOfMeasure unitOfMeasureService, Mapper mapper)
        {
            _unitOfMeasureService = unitOfMeasureService;
            _mapper = mapper;
        }

        [HttpGet("{code}", Name="GetUnitOfMeasure")]
        public ActionResult<UnitOfMeasure> GetUnitOfMeasure(string code) 
        {
            var uom =_unitOfMeasureService.Get(code);
            if(uom == null) return NotFound();
            return Ok(uom);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UnitOfMeasure>> GetAll()
        {
            var uoms = _unitOfMeasureService.GetAll();
            return Ok(uoms);
        }

        [HttpPost]
        public ActionResult Create(UnitOfMeasure unitOfMeasure)
        {
            _unitOfMeasureService.Create(unitOfMeasure);
            _unitOfMeasureService.SaveChanges();
            return CreatedAtRoute(nameof(GetUnitOfMeasure), new {code = unitOfMeasure.Code}, unitOfMeasure);
        }

        [HttpDelete("{code}")]
        public ActionResult Delete(string code)
        {
            var uomFromDb = _unitOfMeasureService.Get(code);
            if(uomFromDb == null) return NotFound();
            _unitOfMeasureService.Delete(uomFromDb);
            _unitOfMeasureService.SaveChanges();
            return NoContent();
        }    
    }
}