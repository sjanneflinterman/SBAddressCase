using System.ComponentModel.DataAnnotations;

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

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public int HouseNumber { get; set; }
    }
}