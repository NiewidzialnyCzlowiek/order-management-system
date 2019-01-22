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

        public DatabaseOperationStatus Delete(int itemId)
        {
            var item = _context.Items.FirstOrDefault( it => it.Id == itemId );
            if(item != null) {
                if (itemPresentOnSalesOrders(item)) {
                    return new DatabaseOperationStatus {
                        StatusOk = false,
                        Message = $"Cannot remove the item because it is used in at least one sales order"
                    };
                }
                _context.Items.Remove(item);
                return SaveChanges();
            }
            return new DatabaseOperationStatus {
                StatusOk = false,
                Message = $"There is no item with id { itemId }"
            };
        }

        private bool itemPresentOnSalesOrders(Item item)
        {
            return _context.SalesOrderLines.Where(line => line.ItemId == item.Id).Count() > 0;
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
            var status = SaveChanges();
            status.NewRecordId = item.Id;
            return status;
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