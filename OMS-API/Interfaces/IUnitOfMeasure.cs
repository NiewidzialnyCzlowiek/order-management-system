using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface IUnitOfMeasure
    {
        DatabaseOperationStatus Insert(UnitOfMeasure unitOfMeasure);
        UnitOfMeasure Get(string code);
        IEnumerable<UnitOfMeasure> GetAll();
        DatabaseOperationStatus Modify(UnitOfMeasure unitOfMeasure);
        DatabaseOperationStatus Delete(string code);
    }
}