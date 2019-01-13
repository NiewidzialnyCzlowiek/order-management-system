using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OMSAPI.DataContext;
using OMSAPI.Interfaces;
using OMSAPI.Models;

namespace OMSAPI.Services
{
    class SalesOrderHeaderService : ISalesOrderHeader
    {
        private OMSDbContext _context;
        public SalesOrderHeaderService(OMSDbContext context) {
            _context = context;
        }

        public DatabaseOperationStatus Delete(int id)
        {
            var salesOrderHeader = _context.SalesOrderHeaders.FirstOrDefault( orderHeader => orderHeader.Id == id);
            if(salesOrderHeader != null) {
                _context.SalesOrderHeaders.Remove(salesOrderHeader);
                return SaveChanges();
            }
            return new DatabaseOperationStatus {
                StatusOk = true,
                Message = $"There is no salesOrderHeader with id: { id }"
            };
        }

        public SalesOrderHeader Get(int id)
        {
            return _context.SalesOrderHeaders.Find(id);
        }

        public IEnumerable<SalesOrderHeader> GetAll()
        {
            return _context.SalesOrderHeaders;
        }

        public DatabaseOperationStatus Insert(SalesOrderHeader salesOrderHeader)
        {
            var tracked = _context.SalesOrderHeaders.Find(salesOrderHeader.Id);
            if(tracked != null) {
                tracked.TransferFields(salesOrderHeader);
                return Modify(tracked);
            }
            _context.SalesOrderHeaders.Add(salesOrderHeader);
            return SaveChanges();
        }

        public DatabaseOperationStatus Modify(SalesOrderHeader salesOrderHeader)
        {
            _context.Entry(salesOrderHeader).State = EntityState.Modified;
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