using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OMSAPI.DataContext;
using OMSAPI.Interfaces;
using OMSAPI.Models;

namespace OMSAPI.Services
{
    class UnitOfMeasureService : IUnitOfMeasure
    {
        private OMSDbContext _context;
        public UnitOfMeasureService(OMSDbContext context) {
            _context = context;
        }

        public DatabaseOperationStatus Delete(string code)
        {
            var unitOfMeasure = _context.UnitsOfMeasure.FirstOrDefault( uom => uom.Code == code);
            if(unitOfMeasure != null) {
                _context.UnitsOfMeasure.Remove(unitOfMeasure);
                return SaveChanges();
            }
            return new DatabaseOperationStatus {
                StatusOk = true,
                Message = $"There is no unitOfMeasure with code: { code }"
            };
        }

        public UnitOfMeasure Get(string code)
        {
            return _context.UnitsOfMeasure.Find(code);
        }

        public IEnumerable<UnitOfMeasure> GetAll()
        {
            return _context.UnitsOfMeasure;
        }

        public DatabaseOperationStatus Insert(UnitOfMeasure unitOfMeasure)
        {
            var tracked = Get(unitOfMeasure.Code);
            if(tracked != null) {
                tracked.Code = unitOfMeasure.Code;
                tracked.Name = unitOfMeasure.Name;
                return Modify(tracked);
            }
            _context.UnitsOfMeasure.Add(unitOfMeasure);
            return SaveChanges();
        }

        public DatabaseOperationStatus Modify(UnitOfMeasure unitOfMeasure)
        {
            _context.Entry(unitOfMeasure).State = EntityState.Modified;
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