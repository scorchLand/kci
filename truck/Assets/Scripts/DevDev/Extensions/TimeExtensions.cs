using System;

namespace DevDev.Extensions
{
	public static class TimeExtensions
	{
		public static string ToFormattedString(this TimeSpan timeSpan, ETimeFormat format)
		{
			switch (format)
			{
				case ETimeFormat.DDHHMMSS:
					return ToDDHHMMSS(timeSpan);
				case ETimeFormat.HHMMSS:
					return ToHHMMSS(timeSpan);
				case ETimeFormat.MMSS:
					return ToMMSS(timeSpan);
				
				case ETimeFormat.DDHHMM:
					return ToDDHHMM(timeSpan);
				case ETimeFormat.HHMM:
					return ToHHMM(timeSpan);
				default:
					return string.Empty;
			}
		}

		public static string ToFormattedString(this TimeSpan timeSpan, ETimeFormat format, ETimeFormat minimum)
		{
			if (format == ETimeFormat.DDHHMM && timeSpan.Days <= 0)
			{
				format = ETimeFormat.HHMM;
			}
			if (format == ETimeFormat.HHMM && timeSpan.Days <= 0)
			{
				format = ETimeFormat.MMSS;
			}

			if (format == ETimeFormat.DDHHMMSS && timeSpan.Days <= 0)
			{
				format = ETimeFormat.HHMMSS;
			}
			if (format == ETimeFormat.HHMMSS && timeSpan.Hours <= 0)
			{
				format = ETimeFormat.MMSS;
			}
			if (format > minimum)
			{
				format = minimum;
			}

			return ToFormattedString(timeSpan, format);
		}
		
		public static string ToDDHHMMSS(this TimeSpan timeSpan)
		{
			return $"{timeSpan.Days}D {timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
		}

		public static string ToHHMMSS(this TimeSpan timeSpan, bool isMinimumFormat = true)
		{
			int hours = timeSpan.Days * 24 + timeSpan.Hours;
			return $"{hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
		}

		public static string ToMMSS(this TimeSpan timeSpan)
		{
			int hours = timeSpan.Days * 24 + timeSpan.Hours;
			int minutes = hours * 60 + timeSpan.Minutes;
			return $"{minutes:D2}:{timeSpan.Seconds:D2}";
		}
		
		public static string ToDDHHMM(this TimeSpan timeSpan)
		{
			return $"{timeSpan.Days}D {timeSpan.Hours:D2}:{timeSpan.Minutes:D2}";
		}

		public static string ToHHMM(this TimeSpan timeSpan)
		{
			return $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}";
		}

		public static TimeSpan ToTimeSpan(this long ticks)
		{
			return TimeSpan.FromTicks(ticks);
		}

		public static DateTime ToDateTime(this long ticks)
		{
			return new DateTime(ticks, DateTimeKind.Utc);
		}

		public static DateTime TimestampToDateTime(this long timestamp)
		{
			var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			return origin.AddSeconds(timestamp);
		}

		public static long DateTimeToTimestamp(this DateTime dateTime)
		{
			var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			var diff = dateTime - origin;
			return (long)Math.Floor(diff.TotalSeconds);
		}
	}
}
