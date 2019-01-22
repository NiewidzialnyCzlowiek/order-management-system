using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface IAddress
    {
        DatabaseOperationStatus Insert(Address address);
        Address Get(int addressId);
        IEnumerable<Address> GetAll();
        IEnumerable<Address> GetAllForCustomer(int customerId);
        DatabaseOperationStatus Modify(Address address);
        DatabaseOperationStatus Delete(int addressId, bool cascade = false);
    }
}