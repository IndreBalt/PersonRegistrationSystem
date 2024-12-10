using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonRegistrationSystem.DataBase.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        [DefaultValue("User")]
        public string Role {  get; set; }        
        public PersonalInfo PersonalInfo { get; set; }

    }
}
