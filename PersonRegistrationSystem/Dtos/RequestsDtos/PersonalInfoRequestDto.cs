using PersonRegistrationSystem.DataBase.Entities;
using PersonRegistrationSystem.Validators;
using System.ComponentModel.DataAnnotations;

namespace PersonRegistrationSystem.Dtos.RequestsDtos
{
    public class PersonalInfoRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [PersonalCodeValidator]
        public long PersonalId { get; set; }
        [Required]
        [PhoneNumberLTValidator]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailValidator]
        public string Email { get; set; }
        [Required]
        public IFormFile ProfilePhoto { get; set; }
        [Required]
        public LivingAddressDto Address { get; set; }
    }
}
