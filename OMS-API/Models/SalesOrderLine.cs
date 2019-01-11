using System.ComponentModel.DataAnnotations.Schema;

namespace OMSAPI.Models
{
    public class SalesOrderLine
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int SalesOrderHeaderId { get; set; }
        public SalesOrderHeader SalesOrderHeader { get; set; }
    }
}