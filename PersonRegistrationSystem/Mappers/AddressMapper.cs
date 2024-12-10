using PersonRegistrationSystem.DataBase.Entities;
using PersonRegistrationSystem.Dtos.RequestsDtos;

namespace PersonRegistrationSystem.Mappers
{
    public interface IAddressMapper
    {
        LivingAddress Map(LivingAddressDto addressDto);
    }
    public class AddressMapper: IAddressMapper
    {
        public LivingAddress Map(LivingAddressDto addressDto)
        {
            return new LivingAddress()
            {
                City = addressDto.City,
                Street = addressDto.Street,
                HouseNumber = addressDto.HouseNumber,
                ApartmentNumber = addressDto.ApartmentNumber
            };
        }
    }

    
}
