using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OMSAPI.Models
{
    public class Customer
    {
        [Key]
        [MaxLength(20)]
        public string No { get; set; }
        [MaxLength(250)]
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}