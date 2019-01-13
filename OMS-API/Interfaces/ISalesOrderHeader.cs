using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface ISalesOrderHeader
    {
        DatabaseOperationStatus Insert(SalesOrderHeader salesOrderHeader);
        SalesOrderHeader Get(int id);
        IEnumerable<SalesOrderHeader> GetAll();
        DatabaseOperationStatus Modify(SalesOrderHeader salesOrderHeader);
        DatabaseOperationStatus Delete(int id);
    }
}