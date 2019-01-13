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
    public class UnitOfMeasureController : ControllerBase
    {
        private IUnitOfMeasure _unitOfMeasureService;
        public UnitOfMeasureController(IUnitOfMeasure unitOfMeasureService)
        {
            _unitOfMeasureService = unitOfMeasureService;
        }

        [HttpGet("{uomCode}")]
        public ActionResult<UnitOfMeasure> Get(string uomCode) 
        {
            return _unitOfMeasureService.Get(uomCode);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UnitOfMeasure>> GetAll()
        {
            return _unitOfMeasureService.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult<DatabaseOperationStatus> Post(UnitOfMeasure unitOfMeasure)
        {
            return _unitOfMeasureService.Insert(unitOfMeasure);
        }    
    }
}