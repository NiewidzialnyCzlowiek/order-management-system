using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface ISalesOrderLine
    {
        DatabaseOperationStatus Insert(SalesOrderLine salesOrderLine);
        SalesOrderLine Get(int id);
        IEnumerable<SalesOrderLine> GetAll();
        IEnumerable<SalesOrderLine> GetAllForSalesOrder(int salesOrderId);
        DatabaseOperationStatus Modify(SalesOrderLine salesOrderLine);
        DatabaseOperationStatus Delete(int id);
    }
}