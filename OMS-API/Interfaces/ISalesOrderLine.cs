using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface ISalesOrderLine
    {
        void Insert(SalesOrderLine salesOrderLine);
        SalesOrderLine Get(int id);
        IEnumerable<SalesOrderLine> GetAll();
        void Modify(SalesOrderLine salesOrderLine);
        void Delete(int id);
    }
}