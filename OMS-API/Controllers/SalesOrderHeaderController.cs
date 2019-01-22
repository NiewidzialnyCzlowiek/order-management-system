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
    public class SalesOrderHeaderController : ControllerBase
    {
        private ISalesOrderHeader _salesOrderHeaderService;
        public SalesOrderHeaderController(ISalesOrderHeader salesOrderHeaderService)
        {
            _salesOrderHeaderService = salesOrderHeaderService;
        }

        [HttpGet("{headerId}")]
        public ActionResult<SalesOrderHeader> Get(int headerId) 
        {
            return _salesOrderHeaderService.Get(headerId);
        }

        [HttpGet]
        public ActionResult<IEnumerable<SalesOrderHeader>> GetAll()
        {
            return _salesOrderHeaderService.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult<DatabaseOperationStatus> Post(SalesOrderHeader orderHeader)
        {
            return _salesOrderHeaderService.Insert(orderHeader);
        }

        [HttpPost("delete")]
        public ActionResult<DatabaseOperationStatus> Delete(DeletionRequest request)
        {
            return _salesOrderHeaderService.Delete(request.IntPk);
        }    
    }
}