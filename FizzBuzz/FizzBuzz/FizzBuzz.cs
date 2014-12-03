using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
	public static class FizzBuzz
	{
		public static string Get(int count)
		{
			IEnumerable<string> numbers = Enumerable.Range(1, count).Select(GetNumberString);
			return string.Join(", ", numbers);
		}

		private static string GetNumberString(int n)
		{
			if (n % 3 == 0 && n % 5 == 0)
			{
				return "Fizz Buzz";
			}
			if (n % 3 == 0)
			{
				return "Fizz";
			}
			if (n % 5 == 0)
			{
				return "Buzz";
			}
			return "" + n;
		}
	}
}