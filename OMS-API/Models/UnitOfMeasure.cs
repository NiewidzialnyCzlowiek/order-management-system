using System.ComponentModel.DataAnnotations;

namespace OMSAPI.Models
{
    public class UnitOfMeasure
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}