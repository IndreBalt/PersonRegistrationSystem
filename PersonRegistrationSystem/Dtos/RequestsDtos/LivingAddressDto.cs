using System.ComponentModel.DataAnnotations;

namespace PersonRegistrationSystem.Dtos.RequestsDtos
{
    public class LivingAddressDto
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
