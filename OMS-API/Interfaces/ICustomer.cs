using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface ICustomer
    {
        DatabaseOperationStatus Insert(Customer customer);
        Customer Get(int customerId);
        IEnumerable<Customer> GetAll();
        DatabaseOperationStatus Modify(Customer customer);
        DatabaseOperationStatus Delete(int customerId, bool cascade = false);
    }
}