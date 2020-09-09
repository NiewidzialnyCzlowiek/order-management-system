using System.ComponentModel.DataAnnotations;

namespace OMSAPI.Dtos.UnitOfMeasureDtos
{
    public class UnitOfMeasureCreateDto
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }
}