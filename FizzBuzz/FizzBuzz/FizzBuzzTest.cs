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


		private static string FizzBuzz(int count)
		{
			var numbers = Enumerable.Range(1, count);
			return string.Join(", ", numbers);
		}
	}
}
