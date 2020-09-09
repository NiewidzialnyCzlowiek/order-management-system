using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface ICustomer
    {
        void Create(Customer customer);
        Customer Get(int id);
        IEnumerable<Customer> GetAll();
        void Update(Customer customer);
        void Delete(Customer customer);
        bool SaveChanges();
    }
}