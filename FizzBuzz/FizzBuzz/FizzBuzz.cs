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
			if (IsDivisibleBy(n, 3) && IsDivisibleBy(n, 5))
			{
				return "Fizz Buzz";
			}
			if (IsDivisibleBy(n, 3))
			{
				return "Fizz";
			}
			if (IsDivisibleBy(n, 5))
			{
				return "Buzz";
			}
			return "" + n;
		}

		private static bool IsDivisibleBy(int n, int divisor)
		{
			return n % divisor == 0;
		}
	}
}