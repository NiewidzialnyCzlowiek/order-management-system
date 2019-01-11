using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface IUnitOfMEasure
    {
        void Insert(UnitOfMeasure address);
        UnitOfMeasure Get(string code);
        IEnumerable<UnitOfMeasure> GetAll();
        void Modify(UnitOfMeasure unitOfMeasure);
        void Delete(string code);
    }
}