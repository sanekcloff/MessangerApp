using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ApplicationData.Utilities.Converters
{
    public static class ImageConverter
    {
        public static byte[]? ImageToBytes(string imagePath)
        {
            var bytes = File.ReadAllBytes(imagePath);
            return bytes;
        }
        public static Image GetImage(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
