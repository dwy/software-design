using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace FizzBuzz
{
	[TestFixture]
	public class FizzBuzzTest
	{
		[Test]
		public void SingleNormalNumber_NumberIsPrinted()
		{
			string numbers = FizzBuzz(1);

			Assert.AreEqual("1", numbers);
		}

		[Test]
		public void NormalNumberSequence_NumbersArePrinted()
		{
			string numbers = FizzBuzz(2);

			Assert.AreEqual("1, 2", numbers);
		}

		[Test]
		public void MultipleOfThree_DisplaysFizz()
		{
			string numbers = FizzBuzz(3);

			Assert.AreEqual("1, 2, Fizz", numbers);
		}

		[Test]
		public void MultipleOfFive_DisplaysBuzz()
		{
			string numbers = FizzBuzz(5);

			Assert.AreEqual("1, 2, Fizz, 4, Buzz", numbers);
		}

		[Test]
		public void MultipleOfFifteen_DisplaysFizzBuzz()
		{
			string numbers = FizzBuzz(15);

			Assert.AreEqual("1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, Fizz Buzz", numbers);
		}

		private static string FizzBuzz(int count)
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
