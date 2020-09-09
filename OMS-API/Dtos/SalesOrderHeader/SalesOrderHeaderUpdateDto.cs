using System;
using System.ComponentModel.DataAnnotations;

namespace OMSAPI.Dtos.SalesOrderHeaderDtos
{
    public class SalesOrderHeaderUpdateDto
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime ShipmentDate { get; set; }
        public decimal Profit { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        [Required]
        public int? AddressId { get; set; }
    }
}