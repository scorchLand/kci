using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

namespace DevDev.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        public static StringBuilder AppendIndent(this StringBuilder builder, int indent)
        {
            for (int i = 0; i < indent; i++)
            {
                builder.Append('\t');
            }

            return builder;
        }
        //public static string ConvertToTenthousandUnits(this long value)
        //{
        //    List<string> tenThousandUnitsList = new List<string>();
        //    long tenThousand = 10000;
        //    StringBuilder strBuilder = new StringBuilder(100);
        //    var unit = Tables.Config.Get(TableConfig.SIMPLIFY_DAMAGETEXT_UNIT).LongValue;
        //    if (value / unit == 0)
        //        return value.ToString();
        //
        //    var final = value / tenThousand;
        //    while (final > 0)
        //    {
        //        var remainder = final % tenThousand;
        //        tenThousandUnitsList.Add(remainder.ToString());
        //        final = final / tenThousand;
        //    }
        //
        //
        //    if (tenThousandUnitsList.Count >= 2)
        //    {
        //        var step = tenThousandUnitsList.Count;
        //        for (int i = tenThousandUnitsList.Count - 1; i > tenThousandUnitsList.Count - 3; i--)
        //        {
        //            if (tenThousandUnitsList[i].Equals("0"))
        //                continue;
        //            strBuilder.Append($"{tenThousandUnitsList[i]}{LocalizeManager.ToLocalize($"NUMBER_STEP_{step}")}");
        //            step--;
        //        }
        //        return strBuilder.ToString();
        //    }
        //    else
        //    {
        //        return $"{tenThousandUnitsList[0]}{LocalizeManager.ToLocalize($"NUMBER_STEP_1")}";
        //    }
        //
        //}
        //public static string ConvertToTenthousandUnits(this BigInteger value)
        //{
        //    List<string> tenThousandUnitsList = new List<string>();
        //    long tenThousand = 10000;
        //    StringBuilder strBuilder = new StringBuilder(100);
        //    var unit = Tables.Config.Get(TableConfig.SIMPLIFY_DAMAGETEXT_UNIT).LongValue;
        //    if (value / unit == 0)
        //        return value.ToString();
        //
        //    var final = value / tenThousand;
        //    while (final > 0)
        //    {
        //        var remainder = final % tenThousand;
        //        tenThousandUnitsList.Add(remainder.ToString());
        //        final = final / tenThousand;
        //    }
        //
        //
        //    if (tenThousandUnitsList.Count >= 2)
        //    {
        //        var step = tenThousandUnitsList.Count;
        //        for (int i = tenThousandUnitsList.Count - 1; i > tenThousandUnitsList.Count - 3; i--)
        //        {
        //            if (tenThousandUnitsList[i].Equals("0"))
        //                continue;
        //            strBuilder.Append($"{tenThousandUnitsList[i]}{LocalizeManager.ToLocalize($"NUMBER_STEP_{step}")}");
        //            step--;
        //        }
        //        return strBuilder.ToString();
        //    }
        //    else
        //    {
        //        return $"{tenThousandUnitsList[0]}{LocalizeManager.ToLocalize($"NUMBER_STEP_1")}";
        //    }
        //
        //}
        public static string[] StringToArray(this string value)
        {
            return value.Split(',');
        }
        public static float[] StringToFloatArray(this string value)
        {
            var stringArray = value.Split(',');
            float[] result = new float[stringArray.Length];
            for (int i = 0; i < stringArray.Length;i++)
            {
                result[i] = Convert.ToSingle(stringArray[i]);
            }
            return result;
        }

        public static string WrapRichTextColor(this string value, Color color)
        {
            string hex = ColorUtility.ToHtmlStringRGBA(color);
            return $"<color=#{hex}>{value}</color>";
        }

        public static string WrapBold(this string value)
        {
            return $"<b>{value}</b>";
        }

        public static string ToPercentage(this float rate, int maxDigit = 0)
            => ToPercentage((double)rate, maxDigit);

        public static string ToPercentage(this double rate, int maxDigit = 0)
        {
            rate *= 100;
            string text = ToCurrencyWithDecimal(rate, maxDigit);
            return $"{text}%";
        }

        public static string ToCurrencyWithDecimal(this float value, int maxDigit)
            => ToCurrencyWithDecimal((double)value, maxDigit);

        public static string ToCurrencyWithDecimal(this double value, int maxDigit)
        {
            long multiply = Mathf.RoundToInt(Mathf.Pow(10, maxDigit));
            long multiplied = (long)Math.Round(value * multiply);
            double final = (double)multiplied / multiply;

            string format = "#,0.";
            for (int i = 0; i < maxDigit; i++)
            {
                format += "#";
            }
            string text = final.ToString(format);
            return text;
        }

        public static string ToFixedDigitPercentage(this float rate, int digit)
            => ToFixedDigitPercentage((double)rate, digit);

        public static string ToFixedDigitPercentage(this double rate, int digit)
        {
            rate *= 100;

            int multiply = Mathf.RoundToInt(Mathf.Pow(10, digit));
            int multiplied = (int)Math.Round(rate * multiply);
            double final = (double)multiplied / multiply;

            string format = "#,00.";
            for (int i = 0; i < digit; i++)
            {
                format += "0";
            }

            string text = final.ToString(format);
            return $"{text}%";
        }

        public static string ToCurrency(this int value)
        {
            return $"{value:#,0}";
        }
        
        public static string ToCurrency(this long value)
        {
            return $"{value:#,0}";
        }
        public static string ToCurrency(this BigInteger value)
        {
            return $"{value:#,0}";
        }

        //public static string ToStringForDayOfWeek(this DayOfWeek value)
        //{
        //    var result = value switch
        //    {
        //        DayOfWeek.Monday => TextKey.MONDAY,
        //        DayOfWeek.Tuesday => TextKey.TUESDAY,
        //        DayOfWeek.Wednesday => TextKey.WEDNESDAY,
        //        DayOfWeek.Thursday => TextKey.THURSDAY,
        //        DayOfWeek.Friday => TextKey.FRIDAY,
        //        DayOfWeek.Saturday => TextKey.SATURDAY,
        //        DayOfWeek.Sunday => TextKey.SUNDAY,
        //        _ => null
        //    };
        //    if (result == null)
        //    {
        //        Debug.LogError($"입력값이 잘못됨 입력 값 : {value}, return : null");
        //        return null;
        //    }
        //    return result;
        //}
        //public static bool IsNickNameCorrect(this string nickname)
        //{
        //    int min = Tables.Config.Get(TableConfig.MIN_NICKNAME_LENGTH).IntValue;
        //    int max = Tables.Config.Get(TableConfig.MAX_NICKNAME_LENGTH).IntValue;
        //
        //    var regex = new Regex($"^[가-힣a-zA-Z]{{1}}[가-힣a-zA-Z0-9]{{{min - 1},{max - 1}}}$");
        //    if (regex.IsMatch(nickname) == false)
        //    {
        //        return false;
        //    }
        //
        //    return Tables.BanWord.List.All(row => !nickname.Contains(row.Key));
        //}
    }
}
