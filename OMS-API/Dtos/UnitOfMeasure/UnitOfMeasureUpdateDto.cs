using System.ComponentModel.DataAnnotations;

namespace OMSAPI.Dtos.UnitOfMeasureDtos
{
    public class UnitOfMeasureUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}