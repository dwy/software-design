using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
	public static class FizzBuzz
	{
		/// <summary>
		/// Map the remainder of n modulo 15 to the corresponding text.
		/// </summary>
		private static readonly Dictionary<int, string> NumberStringForRemaindersOf15 = new Dictionary<int, string>
		{
			{3, "Fizz"},
			{5, "Buzz"},
			{6, "Fizz"},
			{9, "Fizz"},
			{10, "Buzz"},
			{12, "Fizz"},
			{0, "Fizz Buzz"},
		};

		public static string Get(int count)
		{
			IEnumerable<string> numbers = Enumerable.Range(1, count).Select(GetNumberString);
			return string.Join(", ", numbers);
		}

		private static string GetNumberString(int n)
		{
			string numberString;
			NumberStringForRemaindersOf15.TryGetValue(n % 15, out numberString);
			// take advantage of the fact that TryGetValue will assign default(T) if key is not found
			return numberString ?? "" + n;
		}
	}
}