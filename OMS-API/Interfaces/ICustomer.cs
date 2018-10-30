using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface ICustomer
    {
        void Insert(Customer customer);
        Customer Get(string customerNo);
        IEnumerable<Customer> GetAll();
        void Modify(Customer customer);
        void Delete(string customerNo);
    }
}