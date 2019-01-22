using System;
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
                StatusOk = false,
                Message = $"There is no salesOrderHeader with id: { id }"
            };
        }

        public SalesOrderHeader Get(int id)
        {
            return _context.SalesOrderHeaders
                .Include(h => h.Customer)
                .Include(h => h.Address)
                .Include(h => h.Lines)
                .Where(h => h.Id == id)
                .First();
        }

        public IEnumerable<SalesOrderHeader> GetAll()
        {
            return _context.SalesOrderHeaders
                .Include(header => header.Customer)
                .Include(header => header.Address);
                
        }

        public DatabaseOperationStatus Insert(SalesOrderHeader salesOrderHeader)
        {
            validate(salesOrderHeader);
            var tracked = _context.SalesOrderHeaders.Find(salesOrderHeader.Id);
            if(tracked != null) {
                tracked.TransferFields(salesOrderHeader);
                return Modify(tracked);
            }
            _context.SalesOrderHeaders.Add(salesOrderHeader);
            var status = SaveChanges();
            status.NewRecordId = salesOrderHeader.Id;
            return status;
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

        private void validate(SalesOrderHeader header) {
            if (_context.Addresses.Find(header.AddressId) == null) {
                header.AddressId = null;
            }
            if (_context.Customers.Find(header.CustomerId) == null) {
                header.CustomerId = null;
            }
            if (header.OrderDate == default(DateTime)) {
                header.OrderDate = DateTime.Now;
            }
            if (header.ShipmentDate == default(DateTime)) {
                if (header.OrderDate != default(DateTime)) {
                    header.ShipmentDate = header.OrderDate;
                } else {
                    header.ShipmentDate = DateTime.Now;
                }
            }
        }
    }
}