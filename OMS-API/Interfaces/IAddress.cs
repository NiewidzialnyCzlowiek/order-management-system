using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface IAddress
    {
        void Insert(Address address);
        Address Get(int addressId);
        IEnumerable<Address> GetAll();
        IEnumerable<Address> GetAllForCustomer(int customerId);
        void Modify(Address address);
        void Delete(int addressId);
    }
}