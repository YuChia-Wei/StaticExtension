using System.Linq;

namespace StaticExtension
{
    public static class CharArrayExtension
    {
        public static bool IsEngCharArray(this char[] chart)
        {
            return chart.All(c => c.IsEngChar());
        }

        public static bool IsLowerEngCharArray(this char[] chart)
        {
            return chart.All(c => c.IsLowerEngChar());
        }

        public static bool IsNumberCharArray(this char[] chart)
        {
            return chart.All(c => c.IsNumber());
        }

        public static bool IsUpperEngCharArray(this char[] chart)
        {
            return chart.All(c => c.IsUpperEngChar());
        }
    }
}