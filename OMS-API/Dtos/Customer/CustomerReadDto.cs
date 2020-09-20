using System.ComponentModel.DataAnnotations;

namespace OMSAPI.Dtos.CustomerDtos
{
    public class CustomerReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}