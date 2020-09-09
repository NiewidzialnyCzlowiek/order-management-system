using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OMSAPI.DataContext;
using OMSAPI.Interfaces;
using OMSAPI.Models;

namespace OMSAPI.Services
{
    class ItemService : IItem
    {
        private OMSDbContext _context;
        public ItemService(OMSDbContext context) {
            _context = context;
        }

        public void Delete(Item item)
        {
            if(item == null) throw new ArgumentNullException(nameof(item));
            _context.Items.Remove(item);
        }

        public Item Get(int id)
        {
            return _context.Items.Find(id);
        }

        public IEnumerable<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public void Create(Item item)
        {
            if(item == null) throw new ArgumentNullException(nameof(item));
            _context.Items.Add(item);
        }

        public void Update(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
        public bool SaveChanges() {
            return _context.SaveChanges() >= 0;
        }
    }
}