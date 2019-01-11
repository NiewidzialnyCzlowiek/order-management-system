using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface IItem
    {
        void Insert(Item item);
        Item Get(int itemId);
        IEnumerable<Item> GetAll();
        void Modify(Item item);
        void Delete(int itemId);
    }
}