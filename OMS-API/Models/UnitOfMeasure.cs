using System.ComponentModel.DataAnnotations;

namespace OMSAPI.Models
{
    public class UnitOfMeasure
    {
        [Key]
        [MaxLength(20)]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}