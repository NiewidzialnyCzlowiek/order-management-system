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
        public DatabaseOperationStatus Delete(int addressId)
        {
            var addressToDelete = _context.Addresses.FirstOrDefault(addr => addr.Id == addressId);
            if (addressToDelete != null)
            {
                _context.Addresses.Remove(addressToDelete);
                return SaveChanges();
            }
            return new DatabaseOperationStatus {
                StatusOk = true,
                Message = $"There is no address with id: { addressId }"
            };
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

        public DatabaseOperationStatus Insert(Address address)
        {
            var tracked = Get(address.Id);
            if(tracked != null) {
                tracked.TransferFields(address);
                return Modify(tracked);
            }
            _context.Addresses.Add(address);
            return SaveChanges();
        }

        public DatabaseOperationStatus Modify(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            return SaveChanges();
        }
        private DatabaseOperationStatus SaveChanges() {
            try {
                _context.SaveChanges();
            }
            catch(DbUpdateException e) {
                return new DatabaseOperationStatus {
                    StatusOk = false,
                    Message = e.Message
                };
            }
            return new DatabaseOperationStatus {
                StatusOk = true,
                Message = "Operation successful"
            };
        }
    }
}