using System.ComponentModel.DataAnnotations;

namespace PersonRegistrationSystem.Dtos.RequestsDtos
{
    public class UserRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
        public PersonalInfoRequestDto PersonalInfo { get; set; }
    }
}
