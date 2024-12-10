using PersonRegistrationSystem.DataBase.Entities;
using PersonRegistrationSystem.Dtos.RequestsDtos;
using PersonRegistrationSystem.Services;
using System.Drawing.Imaging;

namespace PersonRegistrationSystem.Mappers
{
    public interface IPersonalInfoMapper
    {
        PersonalInfo Map(PersonalInfoRequestDto personalInfoDto);
    }
    public class PersonalInfoMapper: IPersonalInfoMapper
    {
        private readonly IAddressMapper _addressMapper;
        private readonly IPhotoService _photoService;

        public PersonalInfoMapper(IAddressMapper addressMapper, IPhotoService photoService)
        {
            _addressMapper = addressMapper;
            _photoService = photoService;
        }

        public PersonalInfo Map(PersonalInfoRequestDto personalInfoDto)
        {
            var img = _photoService.ResizePhoto(personalInfoDto.ProfilePhoto);
            using var stream = new MemoryStream();
            img.Save(stream, ImageFormat.Png);
            var photoBytes = stream.ToArray();

            return new PersonalInfo()
            {
                FirstName = personalInfoDto.FirstName,
                LastName = personalInfoDto.LastName,
                PersonalId = personalInfoDto.PersonalId,
                PhoneNumber = personalInfoDto.PhoneNumber,
                Email = personalInfoDto.Email,
                ProfilePhoto = photoBytes,
                Address = _addressMapper.Map(personalInfoDto.Address)
            };
    
        }
    }

   
}
