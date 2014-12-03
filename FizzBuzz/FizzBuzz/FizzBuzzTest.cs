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


		private static string FizzBuzz(int count)
		{
			IEnumerable<string> numbers = Enumerable.Range(1, count).Select(GetNumberString);
			return string.Join(", ", numbers);
		}

		private static string GetNumberString(int n)
		{
			if (n % 3 == 0)
			{
				return "Fizz";
			}
			return "" + n;
		}
	}
}
