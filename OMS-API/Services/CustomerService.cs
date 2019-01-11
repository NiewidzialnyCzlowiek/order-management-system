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

        public void Insert(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Delete(int customerId)
        {
            var customerToDelete = _context.Customers.FirstOrDefault(cust => cust.Id == customerId);
            // TODO check if any sales orders exist for the customer
            if (customerToDelete != null)
            {
                _context.Customers.Remove(customerToDelete);
                _context.SaveChanges();
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

        public void Modify(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }
    }
}