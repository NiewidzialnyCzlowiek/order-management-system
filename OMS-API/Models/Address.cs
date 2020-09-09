using System.ComponentModel.DataAnnotations;

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
        // public virtual Customer Customer { get; set; }
        public void TransferFields(Address fromAddress) {
            Country = fromAddress.Country;
            PostCode = fromAddress.PostCode;
            City = fromAddress.City;
            Street = fromAddress.Street;
            BuildingNo = fromAddress.BuildingNo;
            AppartmentNo = fromAddress.AppartmentNo;
            CustomerId = fromAddress.CustomerId;
        }
    }
}