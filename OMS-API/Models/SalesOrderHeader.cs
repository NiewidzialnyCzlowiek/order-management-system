using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMSAPI.Models
{
    public class SalesOrderHeader
    {
        [Key]
        public int No { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        [ForeignKey("Customer")]
        public int SellToCustomerNo { get; set; }
        [ForeignKey("Address")]
        public int ShipToAddressNo { get; set; }

        public virtual Customer SellToCustomer { get; set; }
        public virtual Address ShipToAddress { get; set; }
        public virtual ICollection<SalesOrderLine> Lines { get; set; }
    }
}