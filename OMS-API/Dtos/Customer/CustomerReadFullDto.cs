using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OMSAPI.Dtos.AddressDtos;
using OMSAPI.Models;

namespace OMSAPI.Dtos.CustomerDtos
{
    public class CustomerReadFullDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AddressReadDto> Addresses { get; set; }
    }
}