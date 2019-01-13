using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMSAPI.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        [MaxLength(20)]
        public string UnitOfMeasureCode { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set;}
        public void TransferFields(Item fromItem) {
            Name = fromItem.Name;
            Description = fromItem.Description;
            UnitPrice = fromItem.UnitPrice;
            UnitCost = fromItem.UnitCost;
            UnitOfMeasureCode = fromItem.UnitOfMeasureCode;
        }
    }
}