using System.ComponentModel.DataAnnotations;

namespace OMSAPI.Dtos.CustomerDtos
{
    public class CustomerUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}