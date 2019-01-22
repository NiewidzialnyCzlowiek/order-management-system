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
                var status = SaveChanges();
                status.NewRecordId = customer.Id;
                return status;
            }
        }

        public DatabaseOperationStatus Delete(int customerId, bool cascade = false)
        {
            var customerToDelete = _context.Customers.FirstOrDefault(cust => cust.Id == customerId);
            if (customerToDelete != null)
            {
                if (_context.SalesOrderHeaders.Where(order => order.CustomerId == customerToDelete.Id).Count() > 0) {
                    return new DatabaseOperationStatus {
                        StatusOk = false,
                        Message = "Deletion unsuccesful. There are open Sales Orders for this customer."
                    };
                }
                var addresses = _context.Addresses.Where(addr => addr.CustomerId == customerToDelete.Id);
                if (addresses.Count() > 0)
                {
                    if (!cascade) {
                        return new DatabaseOperationStatus {
                            StatusOk = false,
                            Message = "Deletion unsuccesful. There are Addresses for this customer."
                        };                   
                    } else {
                        _context.Addresses.RemoveRange(addresses);
                    }
                }
                _context.Customers.Remove(customerToDelete);
                return SaveChanges();
            } else {
                return new DatabaseOperationStatus {
                    StatusOk = false,
                    Message = "Deletion unsuccessful"
                };
            }
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