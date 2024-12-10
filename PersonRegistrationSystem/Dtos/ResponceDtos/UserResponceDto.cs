using PersonRegistrationSystem.Dtos.RequestsDtos;
using System.ComponentModel.DataAnnotations;

namespace PersonRegistrationSystem.Dtos.ResponceDtos
{
    public class UserResponceDto   
    {        
        public Guid Id { get; set; }
        public string UserName { get; set; }        
        public PersonalInfoResponceDto PersonalInfo { get; set; }
    }
}
