using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface ISalesOrderHeader
    {
        void Insert(SalesOrderHeader salesOrderHeader);
        SalesOrderHeader Get(int id);
        IEnumerable<SalesOrderHeader> GetAll();
        void Modify(SalesOrderHeader salesOrderHeader);
        void Delete(int id);
    }
}