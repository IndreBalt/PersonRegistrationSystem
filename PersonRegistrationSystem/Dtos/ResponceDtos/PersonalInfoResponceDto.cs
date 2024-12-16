using PersonRegistrationSystem.Dtos.RequestsDtos;
using System.ComponentModel.DataAnnotations;

namespace PersonRegistrationSystem.Dtos.ResponceDtos
{
    public class PersonalInfoResponceDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PersonalId { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }       
        //public byte[] ProfilePhoto { get; set; }      
        public LivingAddressDto Address { get; set; }
    }
}
