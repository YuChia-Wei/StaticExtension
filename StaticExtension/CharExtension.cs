using System;

namespace StaticExtension
{
    public static class CharExtension
    {
        /// <summary>
        /// GetChar字元的ASCII
        /// </summary>
        /// <param name="TransValue"></param>
        /// <returns></returns>
        public static int GetASCII(this char TransValue)
        {
            return Convert.ToInt32(TransValue);
        }

        public static bool IsEngChar(this char chart)
        {
            return chart.IsUpperEngChar() || chart.IsLowerEngChar();
        }

        public static bool IsLowerEngChar(this char chart)
        {
            return chart >= 97 && chart <= 122;
        }

        public static bool IsNumber(this char chart)
        {
            return chart <= 58 && chart >= 47;
        }

        public static bool IsUpperEngChar(this char chart)
        {
            return chart >= 65 && chart <= 90;
        }
    }
}