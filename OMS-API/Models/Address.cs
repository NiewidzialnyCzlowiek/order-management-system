using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMSAPI.Models
{
    public class Address
    {
        [ForeignKey("Customer")]
        public string CustomerNo { get; set; }
        public int AddressNo { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(10)]
        public string PostCode { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Street { get; set; }
        public int BuildingNo { get; set; }
        public int? AppartmentNo { get; set; }

        public virtual Customer Customer { get; set; }
    }
}