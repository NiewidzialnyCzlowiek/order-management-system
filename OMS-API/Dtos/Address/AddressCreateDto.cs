using System.ComponentModel.DataAnnotations;

namespace OMSAPI.Dtos.AddressDtos
{
    public class AddressCreateDto
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public string PostCode { get; set; }
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string BuildingNo { get; set; }
        public string AppartmentNo { get; set; }
        public int CustomerId { get; set; }
    }
}