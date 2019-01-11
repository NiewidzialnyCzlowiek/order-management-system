using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OMSAPI.DataContext;
using OMSAPI.Interfaces;
using OMSAPI.Models;

namespace OMSAPI.Services
{
    class AddressService : IAddress
    {
        private OMSDbContext _context;
        public AddressService(OMSDbContext context) {
            _context = context;
        }
        public void Delete(int addressId)
        {
            var addressToDelete = _context.Addresses.FirstOrDefault(addr => addr.Id == addressId);
            if (addressToDelete != null)
            {
                _context.Addresses.Remove(addressToDelete);
                _context.SaveChanges();
            }
        }

        public Address Get(int addressId)
        {
            return _context.Addresses.Find(addressId);
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses;
        }

        public IEnumerable<Address> GetAllForCustomer(int customerId)
        {
            return _context.Addresses.Where(addr => addr.CustomerId == customerId);
        }

        public void Insert(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void Modify(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }
    }
}