using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface ICustomer
    {
        void Insert(Customer customer);
        Customer Get(int customerId);
        IEnumerable<Customer> GetAll();
        void Modify(Customer customer);
        void Delete(int customerId);
    }
}