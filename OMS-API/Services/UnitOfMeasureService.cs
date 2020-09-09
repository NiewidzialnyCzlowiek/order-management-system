using System;
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

        public void Delete(UnitOfMeasure unitOfMeasure)
        {
            if(unitOfMeasure == null) throw new ArgumentNullException(nameof(unitOfMeasure));
            _context.UnitsOfMeasure.Remove(unitOfMeasure);
        }

        public UnitOfMeasure Get(string code)
        {
            return _context.UnitsOfMeasure.Find(code);
        }

        public IEnumerable<UnitOfMeasure> GetAll()
        {
            return _context.UnitsOfMeasure.ToList();
        }

        public void Create(UnitOfMeasure unitOfMeasure)
        {
            if(unitOfMeasure == null) throw new ArgumentNullException(nameof(unitOfMeasure));
            _context.UnitsOfMeasure.Add(unitOfMeasure);
        }

        public void Update(UnitOfMeasure unitOfMeasure)
        {
            _context.Entry(unitOfMeasure).State = EntityState.Modified;
        }

        public bool SaveChanges() {
            return _context.SaveChanges() >= 0;
        }
    }
}