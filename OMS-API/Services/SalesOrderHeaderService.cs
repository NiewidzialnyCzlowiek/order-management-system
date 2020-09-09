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

        public void Delete(SalesOrderHeader salesOrderHeader)
        {
            if(salesOrderHeader == null) throw new ArgumentNullException(nameof(salesOrderHeader));
            _context.SalesOrderHeaders.Remove(salesOrderHeader);
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
                .Include(header => header.Address)
                .ToList();
                
        }

        public void Create(SalesOrderHeader salesOrderHeader)
        {
            if(salesOrderHeader == null) throw new ArgumentNullException(nameof(salesOrderHeader));
            _context.SalesOrderHeaders.Add(salesOrderHeader);
        }

        public void Update(SalesOrderHeader salesOrderHeader)
        {
            _context.Entry(salesOrderHeader).State = EntityState.Modified;
        }

        public bool SaveChanges() {
            return _context.SaveChanges() >= 0;
        }

        public bool UpdateProfit(int headerId) {
            try {
                var res = _context.Database.ExecuteSqlInterpolated($"CALL public.\"CalcSalesOrderProfit\"({headerId});");
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        private void Validate(SalesOrderHeader header) {
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