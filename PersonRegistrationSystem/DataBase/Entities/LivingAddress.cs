using System.ComponentModel.DataAnnotations;

namespace PersonRegistrationSystem.DataBase.Entities
{
    public class LivingAddress
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }    
        public string Street { get; set; }
        public int HouseNumber {  get; set; }
        public int ApartmentNumber {  get; set; }
    }
}
