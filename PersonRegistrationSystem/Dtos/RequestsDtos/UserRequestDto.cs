using System.ComponentModel.DataAnnotations;

namespace PersonRegistrationSystem.Dtos.RequestsDtos
{
    public class UserRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public PersonalInfoRequestDto PersonalInfo { get; set; }
    }
}
