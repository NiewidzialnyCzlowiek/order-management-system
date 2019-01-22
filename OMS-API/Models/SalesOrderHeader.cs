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
        public decimal Profit { get; set; }
        public int? CustomerId { get; set; }

        public Customer Customer { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public virtual IEnumerable<SalesOrderLine> Lines { get; set; }
        public void TransferFields(SalesOrderHeader fromSalesHeader) {
            OrderDate = fromSalesHeader.OrderDate;
            ShipmentDate = fromSalesHeader.ShipmentDate;
            CustomerId = fromSalesHeader.CustomerId;
            AddressId = fromSalesHeader.AddressId;
        }
    }
}