using System.ComponentModel.DataAnnotations;
using OMSAPI.Models;

namespace OMSAPI.Dtos.ItemDtos
{
    public class ItemCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        [MaxLength(20)]
        [Required]
        public string UnitOfMeasureCode { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set;}
    }
}