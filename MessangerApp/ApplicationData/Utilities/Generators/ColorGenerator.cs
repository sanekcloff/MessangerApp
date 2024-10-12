using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Utilities.Generators
{
    internal static class ColorGenerator
    {
        internal static string GenerateHexColor()
        {
            var random = new Random();
            // Генерируем три случайных числа от 0 до 255 для RGB
            byte r = (byte)random.Next(256);
            byte g = (byte)random.Next(256);
            byte b = (byte)random.Next(256);

            // Преобразуем в формат HEX
            return $"#{r:X2}{g:X2}{b:X2}";
        }
    }
}
