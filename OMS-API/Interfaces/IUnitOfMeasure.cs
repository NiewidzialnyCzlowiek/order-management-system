using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface IUnitOfMeasure
    {
        void Create(UnitOfMeasure unitOfMeasure);
        UnitOfMeasure Get(string code);
        IEnumerable<UnitOfMeasure> GetAll();
        void Update(UnitOfMeasure unitOfMeasure);
        void Delete(UnitOfMeasure unitOfMeasure);
        bool SaveChanges();
    }
}