using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OMSAPI.DataContext;
using OMSAPI.Interfaces;
using OMSAPI.Models;

namespace OMSAPI.Services
{
    public class CustomerService : ICustomer
    {
        private OMSDbContext _context;
        public CustomerService(OMSDbContext context) {
            _context = context;
        }

        public DatabaseOperationStatus Insert(Customer customer)
        {
            var tracked = Get(customer.Id);
            if (tracked != null) {
                tracked.Name = customer.Name;
                return Modify(tracked);
            } else {
                _context.Customers.Add(customer);
                return SaveChanges();
            }
        }

        public DatabaseOperationStatus Delete(int customerId)
        {
            var customerToDelete = _context.Customers.FirstOrDefault(cust => cust.Id == customerId);
            // TODO check if any sales orders exist for the customer
            if (customerToDelete != null)
            {
                _context.Customers.Remove(customerToDelete);
                return SaveChanges();
            }
            return new DatabaseOperationStatus {
                StatusOk = true,
                Message = "Deletion successful"
            };
        }

        public Customer Get(int id)
        {
            return _context.Customers.Find(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers;
        }

        public DatabaseOperationStatus Modify(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
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