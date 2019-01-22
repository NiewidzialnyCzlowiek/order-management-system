using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OMSAPI.Models
{
    public class Customer
    {
        public int Id{ get; set; }
        [Required]
        public string Name { get; set; }
        // public virtual ICollection<Address> Addresses { get; set; }
    }
}