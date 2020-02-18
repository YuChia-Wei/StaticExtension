using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace StaticExtension
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 將DateTime轉換成民國年
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="Format"></param>
        /// <returns></returns>
        public static string ToTaiwanDate(this DateTime dateTime, string Format)
        {
            TaiwanCalendar tc = new TaiwanCalendar();
            Regex regex = new System.Text.RegularExpressions.Regex(@"[yY]+");
            Format = regex.Replace(Format, tc.GetYear(dateTime).ToString("000"));
            return dateTime.ToString(Format);
        }
    }
}