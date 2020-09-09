using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface IAddress
    {
        void Create(Address address);
        Address Get(int addressId);
        IEnumerable<Address> GetAll();
        IEnumerable<Address> GetAllForCustomer(int customerId);
        void Update(Address address);
        void Delete(Address address);
        bool SaveChanges();
    }
}