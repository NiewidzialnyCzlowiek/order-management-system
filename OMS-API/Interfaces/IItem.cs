using System.Collections.Generic;
using OMSAPI.Models;

namespace OMSAPI.Interfaces
{
    public interface IItem
    {
        DatabaseOperationStatus Insert(Item item);
        Item Get(int itemId);
        IEnumerable<Item> GetAll();
        DatabaseOperationStatus Modify(Item item);
        DatabaseOperationStatus Delete(int itemId);
    }
}