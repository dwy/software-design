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

		private static string FizzBuzz(int count)
		{
			return "" + count;
		}
	}
}
