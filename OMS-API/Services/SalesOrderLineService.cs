using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OMSAPI.DataContext;
using OMSAPI.Interfaces;
using OMSAPI.Models;

namespace OMSAPI.Services
{
    class SalesOrderLineService : ISalesOrderLine
    {
        private OMSDbContext _context;
        public SalesOrderLineService(OMSDbContext context) {
            _context = context;
        }

        public DatabaseOperationStatus Delete(int id)
        {
            var salesOrderLine = _context.SalesOrderLines.FirstOrDefault( orderLine => orderLine.Id == id);
            if(salesOrderLine != null) {
                _context.SalesOrderLines.Remove(salesOrderLine);
                return SaveChanges();
            }
            return new DatabaseOperationStatus {
                StatusOk = true,
                Message = $"There is no Sales Order Line with id: { id }"
            };
        }

        public SalesOrderLine Get(int id)
        {
            return _context.SalesOrderLines.Find(id);
        }

        public IEnumerable<SalesOrderLine> GetAll()
        {
            return _context.SalesOrderLines;
        }

        public IEnumerable<SalesOrderLine> GetAllForSalesOrder(int salesOrderId)
        {
            return _context.SalesOrderLines.Where(line => line.SalesOrderHeaderId == salesOrderId);
        }

        public DatabaseOperationStatus Insert(SalesOrderLine salesOrderLine)
        {
            var tracked = _context.SalesOrderLines.Find(salesOrderLine.Id);
            if(tracked != null) {
                tracked.TransferFields(salesOrderLine);
                return Modify(tracked);
            }
            _context.SalesOrderLines.Add(salesOrderLine);
            return SaveChanges();
        }

        public DatabaseOperationStatus Modify(SalesOrderLine salesOrderLine)
        {
            _context.Entry(salesOrderLine).State = EntityState.Modified;
            return SaveChanges();
        }

        private DatabaseOperationStatus SaveChanges() {
            try {
                _context.SaveChanges();
            }
            catch(DbUpdateException e) {
                return new DatabaseOperationStatus {
                    StatusOk = false,
                    Message = e.Message
                };
            }
            return new DatabaseOperationStatus {
                StatusOk = true,
                Message = "Operation successful"
            };
        }
    }
}