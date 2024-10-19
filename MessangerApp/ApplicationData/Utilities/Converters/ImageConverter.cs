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
            return File.ReadAllBytes(imagePath);
        }
        public static Image GetImage(byte[] byteArray)
        {
            return Image.FromStream(new MemoryStream(byteArray));
        }
    }
}
