using System.ComponentModel.DataAnnotations;

namespace PersonRegistrationSystem.DataBase.Entities
{
    public class PersonalInfo
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PersonalId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public LivingAddress Address { get; set; }

    }
}
