using System.ComponentModel.DataAnnotations.Schema;

namespace OMSAPI.Models
{
    public class SalesOrderLine
    {
        [ForeignKey("SalesOrderHeader")]
        public int OrderHeaderNo { get; set; }
        public int LineNo { get; set; }
        public virtual Item Item { get; set; }
        public decimal Quantity { get; set; }
        public virtual SalesOrderHeader OrderHeader { get; set; }
    }
}