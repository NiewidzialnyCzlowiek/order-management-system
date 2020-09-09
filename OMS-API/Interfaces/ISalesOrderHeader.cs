using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface ISalesOrderHeader
    {
        void Create(SalesOrderHeader salesOrderHeader);
        SalesOrderHeader Get(int id);
        IEnumerable<SalesOrderHeader> GetAll();
        void Update(SalesOrderHeader salesOrderHeader);
        void Delete(SalesOrderHeader salesOrderHeader);
        bool UpdateProfit(int headerId);
        bool SaveChanges();
    }
}