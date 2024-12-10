using Microsoft.AspNetCore.Http;
using System.Drawing;

namespace PersonRegistrationSystem.Services
{
    public interface IPhotoService
    {
        Image ResizePhoto(IFormFile photo);
    }
    public class PhotoService: IPhotoService
    {
        public Image ResizePhoto(IFormFile photo)
        {
            var stream = new MemoryStream();
            photo.CopyTo(stream);
            var img = Image.FromStream(stream);
            Bitmap bitmap = new Bitmap(img, new Size(200, 200));
            Image image = bitmap;
            return image;
        }
    }

   
}
