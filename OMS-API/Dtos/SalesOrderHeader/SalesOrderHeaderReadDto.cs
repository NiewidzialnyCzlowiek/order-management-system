using System;
using System.Collections.Generic;
using OMSAPI.Dtos.AddressDtos;
using OMSAPI.Dtos.CustomerDtos;
using OMSAPI.Dtos.SalesOrderLineDtos;
using OMSAPI.Models;

namespace OMSAPI.Dtos.SalesOrderHeaderDtos
{
    public class SalesOrderHeaderReadDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int? CustomerId { get; set; }
        public CustomerReadDto Customer { get; set; }
        public int? AddressId { get; set; }
        public AddressReadDto Address { get; set; }
        public virtual IEnumerable<SalesOrderLineReadDto> Lines { get; set; }

    }
}