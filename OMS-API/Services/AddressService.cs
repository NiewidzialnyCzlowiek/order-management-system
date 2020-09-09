using System;
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
        public void Delete(Address address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            _context.Addresses.Remove(address);
        }

        public Address Get(int addressId)
        {
            return _context.Addresses.Find(addressId);
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }

        public IEnumerable<Address> GetAllForCustomer(int customerId)
        {
            return _context.Addresses.Where(addr => addr.CustomerId == customerId);
        }

        public void Create(Address address)
        {
            if(address == null) throw new ArgumentNullException(nameof(address));
            _context.Addresses.Add(address);
        }

        public void Update(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
        }
        public bool SaveChanges() {
            return _context.SaveChanges() >= 0;
        }
    }
}