using System.ComponentModel.DataAnnotations;

namespace OMSAPI.Dtos.CustomerDtos
{
    public class CustomerCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}