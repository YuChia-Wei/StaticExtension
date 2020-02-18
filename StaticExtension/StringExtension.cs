using System;
using System.Linq;

namespace StaticExtension
{
    public static class StringExtension
    {
        /// <summary>
        /// 字串是否為英文字串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEngString(this string str)
        {
            return str.IsEngString(0, str.Length);
        }

        /// <summary>
        /// 字串是否為英文字串 (指定起始點到字串結尾)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static bool IsEngString(this string str, int startIndex)
        {
            return str.IsEngString(startIndex, str.Length);
        }

        /// <summary>
        /// 字串是否為英文字串 (指定起始點與要判斷的字串長度)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="strLength"></param>
        /// <returns></returns>
        public static bool IsEngString(this string str, int startIndex, int strLength)
        {
            if (startIndex >= str.Length || ((strLength + startIndex) > str.Length && strLength != str.Length))
                return false;

            if (str.Length == strLength)
            {
                return str.ToCharArray(startIndex, strLength - startIndex).All(ch => ch.IsEngChar());
            }
            else
            {
                return str.ToCharArray(startIndex, strLength).All(ch => ch.IsEngChar());
            }
        }

        /// <summary>
        /// 字串是否為英文字串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsLowerEngString(this string str)
        {
            return str.IsLowerEngString(0, str.Length);
        }

        /// <summary>
        /// 字串是否為英文字串 (指定起始點到字串結尾)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static bool IsLowerEngString(this string str, int startIndex)
        {
            return str.IsLowerEngString(startIndex, str.Length - startIndex);
        }

        /// <summary>
        /// 字串是否為英文字串 (指定起始點與要判斷的字串長度)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="strLength"></param>
        /// <returns></returns>
        public static bool IsLowerEngString(this string str, int startIndex, int strLength)
        {
            if (startIndex >= str.Length || ((strLength + startIndex) > str.Length && strLength != str.Length))
                return false;

            if (str.Length == strLength)
            {
                return str.ToCharArray(startIndex, strLength - startIndex).All(ch => ch.IsLowerEngChar());
            }
            else
            {
                return str.ToCharArray(startIndex, strLength).All(ch => ch.IsLowerEngChar());
            }
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        #region 統一發票號碼驗證

        /// <summary>
        /// 是否為台灣統一發票號碼格式 [NN00000000]，前綴部分不允許小寫 (Uniform Invoice)
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <returns></returns>
        public static bool IsTwUniformInvoice(this string InvoiceNum)
        {
            return CheckInvoiceLength(InvoiceNum) &&
                   InvoiceNum.IsTwPublicSectorInvoicePrefix() == false &&
                   InvoiceNum.IsTwUniformInvoicePrefix() &&
                   InvoiceNum.IsNumber(2);
        }

        private static bool CheckInvoiceLength(string InvoiceNum)
        {
            return InvoiceNum.Length == 10;
        }

        /// <summary>
        /// 是否為台灣公營單位發票的字軌前綴
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        private static bool IsTwPublicSectorInvoicePrefix(this string invoiceNum)
        {
            return invoiceNum.StartsWith("BB", StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 是否為台灣統一發票的字軌前綴
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        private static bool IsTwUniformInvoicePrefix(this string invoiceNum)
        {
            if (invoiceNum.Length < 2)
                return false;

            if (invoiceNum.ToCharArray(0, 2).All(ch => ch == 79 || ch == 73))
                return false;

            return !invoiceNum.IsTwPublicSectorInvoicePrefix() && invoiceNum.IsUpperEngString(0, 2);
        }

        #endregion 統一發票號碼驗證

        #region 公司統編檢驗

        /// <summary>
        /// 是否為統編 Business Administration Number (BAN)
        /// </summary>
        /// <param name="BAN"></param>
        /// <returns></returns>
        public static bool IsBAN(this string BAN)
        {
            if (BAN.Length != 8)
                return false;

            int[] cx = new int[8] { 1, 2, 1, 2, 1, 2, 4, 1 };
            int SUM = 0;
            try
            {
                for (int i = 0; i <= 7; i++)
                {
                    SUM += CalBANNumLogic(int.Parse(BAN.Substring(i, 1)) * cx[i]);
                }
            }
            catch
            {
                return false;
            }

            return SUM % 10 == 0 || ((BAN.Substring(6, 1) == "7" && (SUM + 1) % 10 == 0));
        }

        private static int CalBANNumLogic(int n)
        {
            if (n <= 9) return n;

            n = n % 10 + (n - n % 10) / 10;

            return n;
        }

        #endregion 公司統編檢驗

        /// <summary>
        /// 字串為數字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumber(this string str)
        {
            return str.IsNumber(0, str.Length);
        }

        /// <summary>
        /// 字串為數字
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static bool IsNumber(this string str, int startIndex)
        {
            return str.IsNumber(startIndex, str.Length);
        }

        /// <summary>
        /// 字串為數字
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="strLength"></param>
        /// <returns></returns>
        public static bool IsNumber(this string str, int startIndex, int strLength)
        {
            if (startIndex >= str.Length || ((strLength + startIndex) > str.Length && strLength != str.Length))
                return false;

            if (str.Length == strLength)
            {
                return str.ToCharArray(startIndex, strLength - startIndex).All(ch => ch.IsNumber());
            }
            else
            {
                return str.ToCharArray(startIndex, strLength).All(ch => ch.IsNumber());
            }
        }

        /// <summary>
        /// 字串是否為英文字串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUpperEngString(this string str)
        {
            return str.IsUpperEngString(0, str.Length);
        }

        /// <summary>
        /// 字串是否為英文字串 (指定起始點到字串結尾)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static bool IsUpperEngString(this string str, int startIndex)
        {
            return str.IsUpperEngString(startIndex, str.Length);
        }

        /// <summary>
        /// 字串是否為英文字串 (指定起始點與要判斷的字串長度)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="strLength"></param>
        /// <returns></returns>
        public static bool IsUpperEngString(this string str, int startIndex, int strLength)
        {
            if (startIndex >= str.Length || ((strLength + startIndex) > str.Length && strLength != str.Length))
                return false;
            if (str.Length == strLength)
            {
                return str.ToCharArray(startIndex, strLength - startIndex).All(ch => ch.IsUpperEngChar());
            }
            else
            {
                return str.ToCharArray(startIndex, strLength).All(ch => ch.IsUpperEngChar());
            }
        }
    }
}