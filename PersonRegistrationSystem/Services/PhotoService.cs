using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Imaging;

namespace PersonRegistrationSystem.Services
{
    public interface IPhotoService
    {
        byte[] PhotoToBytes(IFormFile photo);
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
        public byte[] PhotoToBytes(IFormFile photo)
        {
            var img = ResizePhoto(photo);
            using var stream = new MemoryStream();
            img.Save(stream, ImageFormat.Png);
            var photoBytes = stream.ToArray();
            return photoBytes;
        }
    }

   
}
