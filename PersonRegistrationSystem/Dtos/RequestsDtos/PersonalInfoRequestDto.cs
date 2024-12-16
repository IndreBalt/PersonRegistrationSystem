using PersonRegistrationSystem.DataBase.Entities;
using System.ComponentModel.DataAnnotations;

namespace PersonRegistrationSystem.Dtos.RequestsDtos
{
    public class PersonalInfoRequestDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public long PersonalId { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public IFormFile ProfilePhoto { get; set; }
        public LivingAddressDto Address { get; set; }
    }
}
