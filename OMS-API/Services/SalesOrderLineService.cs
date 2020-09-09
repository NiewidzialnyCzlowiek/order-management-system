using System;
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

        public void Delete(SalesOrderLine salesOrderLine)
        {
            if(salesOrderLine == null) throw new ArgumentNullException(nameof(salesOrderLine));
            _context.SalesOrderLines.Remove(salesOrderLine);
        }

        public SalesOrderLine Get(int id)
        {
            return _context.SalesOrderLines
                .Include(line => line.Item)
                .FirstOrDefault(line => line.Id == id);
        }

        public IEnumerable<SalesOrderLine> GetAll()
        {
            return _context.SalesOrderLines.ToList();
        }

        public IEnumerable<SalesOrderLine> GetAllForSalesOrder(int salesOrderId)
        {
            return _context.SalesOrderLines
                .Where(line => line.SalesOrderHeaderId == salesOrderId)
                .Include(line => line.Item)
                .ToList();
        }

        public void Create(SalesOrderLine salesOrderLine)
        {
            if(salesOrderLine == null) throw new ArgumentNullException(nameof(salesOrderLine));
            _context.SalesOrderLines.Add(salesOrderLine);
        }

        public void Update(SalesOrderLine salesOrderLine)
        {
            _context.Entry(salesOrderLine).State = EntityState.Modified;
        }

        public bool SaveChanges() {
            return _context.SaveChanges() >= 0;
        }

        private bool UpdateLineAmount(int id) {
            try {
                var res = _context.Database.ExecuteSqlInterpolated($"CALL public.\"CalcSalesOrderLineAmount\"({id});");
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

    }
}