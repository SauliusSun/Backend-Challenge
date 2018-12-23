namespace Backend_Challenge.Helpers
{
	public static class StringHelper
	{
		public const string WhiteSpace = " ";

		public static char GetComparable(this char value)
		{
			return char.ToLowerInvariant(value);
		}

		public static string GetComparable(this string value)
		{
			return value.Trim().Replace(WhiteSpace, string.Empty).ToLowerInvariant();
		}
	}
}
