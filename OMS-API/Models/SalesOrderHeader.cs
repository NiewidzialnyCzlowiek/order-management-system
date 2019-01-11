using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMSAPI.Models
{
    public class SalesOrderHeader
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<SalesOrderLine> Lines { get; set; }
    }
}