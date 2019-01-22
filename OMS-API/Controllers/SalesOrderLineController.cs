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
    public class SalesOrderLineController : ControllerBase
    {
        private ISalesOrderLine _salesOrderLineService;
        public SalesOrderLineController(ISalesOrderLine salesOrderLineService)
        {
            _salesOrderLineService = salesOrderLineService;
        }

        [HttpGet("{lineId}")]
        public ActionResult<SalesOrderLine> Get(int lineId) 
        {
            return _salesOrderLineService.Get(lineId);
        }
        [HttpGet("forHeader/{headerId}")]
        public ActionResult<IEnumerable<SalesOrderLine>> GetAllForSalesOrderHeader(int headerId)
        {
            return _salesOrderLineService.GetAllForSalesOrder(headerId).ToArray();
        }

        [HttpGet]
        public ActionResult<IEnumerable<SalesOrderLine>> GetAll()
        {
            return _salesOrderLineService.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult<DatabaseOperationStatus> Post(SalesOrderLine orderLine)
        {
            return _salesOrderLineService.Insert(orderLine);
        }    
        [HttpPost("delete")]
        public ActionResult<DatabaseOperationStatus> Delete(DeletionRequest request)
        {
            return _salesOrderLineService.Delete(request.IntPk);
        }    
    }
}