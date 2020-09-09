using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface IItem
    {
        void Create(Item item);
        Item Get(int itemId);
        IEnumerable<Item> GetAll();
        void Update(Item item);
        void Delete(Item item);
        bool SaveChanges();
    }
}