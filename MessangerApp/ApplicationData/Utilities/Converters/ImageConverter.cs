using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;

namespace ApplicationData.Utilities.Converters
{
    public static class ImageConverter
    {
        public static byte[]? ImageToBytes(string imagePath) => File.ReadAllBytes(imagePath);
        public static BitmapImage GetBitmapImage(byte[] byteArray) 
        {
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // Загружает изображение в память
                bitmapImage.EndInit();
                bitmapImage.Freeze(); // Замораживаем объект, чтобы его можно было использовать в других потоках
                return bitmapImage;
            }
        }
    }
}
