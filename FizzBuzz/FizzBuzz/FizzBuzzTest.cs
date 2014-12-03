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
			string numbers = FizzBuzz.Get(1);

			Assert.AreEqual("1", numbers);
		}

		[Test]
		public void NormalNumberSequence_NumbersArePrinted()
		{
			string numbers = FizzBuzz.Get(2);

			Assert.AreEqual("1, 2", numbers);
		}

		[Test]
		public void MultipleOfThree_DisplaysFizz()
		{
			string numbers = FizzBuzz.Get(3);

			Assert.AreEqual("1, 2, Fizz", numbers);
		}

		[Test]
		public void MultipleOfFive_DisplaysBuzz()
		{
			string numbers = FizzBuzz.Get(5);

			Assert.AreEqual("1, 2, Fizz, 4, Buzz", numbers);
		}

		[Test]
		public void MultipleOfFifteen_DisplaysFizzBuzz()
		{
			string numbers = FizzBuzz.Get(15);

			Assert.AreEqual("1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, Fizz Buzz", numbers);
		}
	}
}
