using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBData.Entities
{
    public class Address
    {
        public int Id { get; init; }
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]//TODO: Add regex 
        public string PostalCode { get; set; }

        [Required]
        public int HouseNumber { get; set; }
    }
}