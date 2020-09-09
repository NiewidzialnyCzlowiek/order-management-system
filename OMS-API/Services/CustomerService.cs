using System;
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

        public void Create(Customer customer)
        {
            if(customer == null) throw new ArgumentNullException(nameof(customer));
            _context.Customers.Add(customer);
        }

        public void Delete(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            _context.Customers.Remove(customer);
        }

        public Customer Get(int id)
        {
            return _context.Customers.Find(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
        public bool SaveChanges() {
            return _context.SaveChanges() >= 0;
        }
    }
}