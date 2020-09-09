using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface ISalesOrderLine
    {
        void Create(SalesOrderLine salesOrderLine);
        SalesOrderLine Get(int id);
        IEnumerable<SalesOrderLine> GetAll();
        IEnumerable<SalesOrderLine> GetAllForSalesOrder(int salesOrderId);
        void Update(SalesOrderLine salesOrderLine);
        void Delete(SalesOrderLine salesOrderLine);
        bool SaveChanges();
    }
}