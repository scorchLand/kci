using System;
using UnityEngine;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace DevDev.Extensions
{
	public static class TypeExtensions
	{
		public static int ToInt(this string value) => int.Parse(value, CultureInfo.InvariantCulture);
		public static long ToLong(this string value) => long.Parse(value, CultureInfo.InvariantCulture);
		public static float ToFloat(this string value) => float.Parse(value, CultureInfo.InvariantCulture);
		public static double ToDouble(this string value) => double.Parse(value, CultureInfo.InvariantCulture);
		public static TimeSpan ToTimeSpan(this string value) => TimeSpan.Parse(value, CultureInfo.InvariantCulture);
		public static DayOfWeek ToDayOfWeek(this string value)
		{
			var result = value switch
			{
				"Monday" => DayOfWeek.Monday,
				"Tuesday" => DayOfWeek.Tuesday,
				"Wednesday" => DayOfWeek.Wednesday,
				"Thursday" => DayOfWeek.Thursday,
				"Friday" =>	DayOfWeek.Friday,
				"Saturday" => DayOfWeek.Saturday,
				"Sunday" => DayOfWeek.Sunday,
				_=>DayOfWeek.Monday
			};
			if(result.ToString() != value)
			{
				Debug.LogError($"입력된 요일 잘못됨 입력 값 : {value}, Default 값 : {DayOfWeek.Monday}");
			}
			return result;
		}
		public static int AbsoluteToOverflow(this int value, int b)
        {
			if(value > int.MaxValue - b)
            {
				Debug.LogWarning($"{value.GetType()}값이 최대에 도달했습니다 - {int.MaxValue}");
				return int.MaxValue;
            }
			else
            {
				return value + b;
            }
        }
		public static long AbsoluteToOverflow(this long value, long b)
        {
			if(value > long.MaxValue - b)
            {
				Debug.LogWarning($"{value.GetType()}값이 최대에 도달했습니다 - {long.MaxValue}");
				return long.MaxValue;
            }
			else
            {
				return value + b;
            }
        }
		public static TEnum ToEnum<TEnum>(this string value) where TEnum : struct
		{
			if (Enum.TryParse(value, out TEnum result) == false)
			{
				if (value.IsNullOrWhiteSpace() == false)
				{
					Debug.LogError($"Enum:{typeof(TEnum).Name} 파싱 실패: {value}");
				}
				return default;
			}
			return result;
		}
		public static JArray ToJArrayParams(params object[] value)
		{
			var result = new JArray();
			foreach (var item in value)
			{
				result.Add(JToken.FromObject(item));
			}
			return result;
		}
		public static JArray ToJArray(this object[] value)
		{
			var result = new JArray();
			foreach (var item in value)
			{
				result.Add(JToken.FromObject(item));
			}
			return result;
		}
		public static JArray ToJArray<T>(this List<T> value)
		{
			var result = new JArray();
			foreach (var item in value)
			{
				result.Add(JToken.FromObject(item));
			}
			return result;
		}
		public static JArray ToJArray<TKey,TValue>(this Dictionary<TKey,TValue> value)
		{
			var result = new JArray();
			foreach (var item in value)
			{
				result.Add(JToken.FromObject(item));
			}
			return result;
		}
	}
}
