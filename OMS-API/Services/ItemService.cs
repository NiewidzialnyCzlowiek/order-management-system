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

        public DatabaseOperationStatus Delete(int itemId)
        {
            var item = _context.Items.FirstOrDefault( it => it.Id == itemId );
            if(item != null) {
                _context.Items.Remove(item);
                return SaveChanges();
            }
            return new DatabaseOperationStatus {
                StatusOk = true,
                Message = $"There is no item with id { itemId }"
            };
        }

        public Item Get(int itemId)
        {
            return _context.Items.Find(itemId);
        }

        public IEnumerable<Item> GetAll()
        {
            return _context.Items;
        }

        public DatabaseOperationStatus Insert(Item item)
        {
            var tracked = Get(item.Id);
            if(tracked != null) {
                tracked.TransferFields(item);
                return Modify(tracked);
            }
            _context.Items.Add(item);
            return SaveChanges();
        }

        public DatabaseOperationStatus Modify(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
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