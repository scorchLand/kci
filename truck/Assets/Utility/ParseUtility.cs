using System.Linq;
using DevDev.Extensions;
using System.Globalization;

public static class ParseUtility
{
	public static string[] ToStringArray(this string value)
	{
		if (value.IsNullOrWhiteSpace())
		{
			return System.Array.Empty<string>();
		}
		
		return value.Replace(" ","").Split(',').Select(str => str.Trim()).ToArray();
	}
	
	public static float[] ToFloatArray(this string value)
	{
		if (value.IsNullOrWhiteSpace())
		{
			return System.Array.Empty<float>();
		}
		
		return value.Replace(" ","").Split(',').Select(str => str.Trim()).Select((string s)=>{ return float.Parse(s, CultureInfo.InvariantCulture); }).ToArray();
	}
	
	public static int[] ToIntArray(this string value)
	{
		if (value.IsNullOrWhiteSpace())
		{
			return System.Array.Empty<int>();
		}
		
		return value.Replace(" ","").Split(',').Select(str => str.Trim()).Select(int.Parse).ToArray();
	}
	
	public static long[] ToLongArray(this string value)
	{
		if (value.IsNullOrWhiteSpace())
		{
			return System.Array.Empty<long>();
		}
		
		return value.Replace(" ","").Split(',').Select(str => str.Trim()).Select(long.Parse).ToArray();
	}
}
