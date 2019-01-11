using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMSAPI.Models
{
    public class Address
    {
        public int Id { get; set; }
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
        public Customer Customer { get; set; }
    }
}