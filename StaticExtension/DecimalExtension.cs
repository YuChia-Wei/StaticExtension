using System;

namespace StaticExtension
{
    public static class DecimalExtension
    {
        /// <summary>
        /// 取得四捨五入後的整數值
        /// </summary>
        /// <param name="valueDecimal"></param>
        /// <param name="midpointRounding">轉換方式</param>
        /// <returns></returns>
        public static decimal GetRoundingResult(this decimal valueDecimal, MidpointRounding midpointRounding)
        {
            return valueDecimal.GetRoundingResult(0, midpointRounding);
        }

        /// <summary>
        /// 取得四捨五入後的數值
        /// </summary>
        /// <param name="valueDecimal"></param>
        /// <param name="decimals">取到小數後幾位</param>
        /// <param name="midpointRounding">轉換方式</param>
        /// <returns></returns>
        public static decimal GetRoundingResult(this decimal valueDecimal, int decimals, MidpointRounding midpointRounding)
        {
            return decimal.Round(valueDecimal, decimals, midpointRounding);
        }

        public static bool IsInteger(this decimal valueDecimal)
        {
            return valueDecimal % 1.0m == 0m;
        }

        /// <summary>
        /// 取得四捨五入的整數值
        /// </summary>
        /// <param name="valueDecimal"></param>
        /// <returns></returns>
        public static decimal RoundToInteger(this decimal valueDecimal)
        {
            return valueDecimal.GetRoundingResult(MidpointRounding.AwayFromZero);
        }
    }
}