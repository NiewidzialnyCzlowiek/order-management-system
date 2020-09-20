using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMSAPI.Dtos.UnitOfMeasureDtos;
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
        public UnitOfMeasureController(IUnitOfMeasure unitOfMeasureService, IMapper mapper)
        {
            _unitOfMeasureService = unitOfMeasureService;
            _mapper = mapper;
        }

        [HttpGet("{code}", Name="GetUnitOfMeasure")]
        public ActionResult<UnitOfMeasureReadFullDto> GetUnitOfMeasure(string code) 
        {
            var uom =_unitOfMeasureService.Get(code);
            if(uom == null) return NotFound();
            return Ok(_mapper.Map<UnitOfMeasureReadFullDto>(uom));
        }

        [HttpGet]
        public ActionResult<IEnumerable<UnitOfMeasureReadDto>> GetAll()
        {
            var uoms = _unitOfMeasureService.GetAll();
            return Ok(_mapper.Map<IEnumerable<UnitOfMeasureReadDto>>(uoms));
        }

        [HttpPost]
        public ActionResult Create(UnitOfMeasureCreateDto unitOfMeasureCreateDto)
        {
            var unitOfMeasureModel = _mapper.Map<UnitOfMeasure>(unitOfMeasureCreateDto);
            _unitOfMeasureService.Create(unitOfMeasureModel);
            _unitOfMeasureService.SaveChanges();
            var unitOfMeasureReadFullDto = _mapper.Map<UnitOfMeasureReadFullDto>(unitOfMeasureModel);
            return CreatedAtRoute(nameof(GetUnitOfMeasure), new {code = unitOfMeasureReadFullDto.Code}, unitOfMeasureReadFullDto);
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

        [HttpPut("{code}")]
        public ActionResult Update(string code, UnitOfMeasureUpdateDto unitOfMeasureUpdateDto)
        {
            var uomFromDb = _unitOfMeasureService.Get(code);
            if(uomFromDb == null) return NotFound();
            _mapper.Map(unitOfMeasureUpdateDto, uomFromDb);
            _unitOfMeasureService.Update(uomFromDb);
            _unitOfMeasureService.SaveChanges();
            return NoContent();
        }
    }
}