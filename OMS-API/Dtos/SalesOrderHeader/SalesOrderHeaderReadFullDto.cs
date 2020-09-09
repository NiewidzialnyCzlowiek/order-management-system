using System;
using OMSAPI.Dtos.AddressDtos;
using OMSAPI.Dtos.CustomerDtos;

namespace OMSAPI.Dtos.SalesOrderHeaderDtos
{
    public class SalesOrderHeaderReadFullDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public decimal Profit { get; set; }
        public int? CustomerId { get; set; }
        public CustomerReadFullDto Customer { get; set; }
        public int? AddressId { get; set; }
        public AddressReadFullDto Address { get; set; }
    }
}