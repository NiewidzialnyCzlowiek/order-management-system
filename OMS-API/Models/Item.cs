using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMSAPI.Models
{
    public class Item
    {
        [Key]
        public int No { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        [ForeignKey("UnitOfMeasure")]
        public string UnitOfMeasureCode { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure { get; set;}
    }
}