using NUnit.Framework;

namespace Person
{
	[TestFixture]
	public class PersonTest
	{
		[Test]
		public void ToString_defaultMode()
		{
			Person simon = new Person("Ammann", "Simon", "CH");
			Assert.AreEqual("Simon Ammann", simon.ToString());
		}

		[Test]
		public void ToString_Capitalize()
		{
			Person simon = new Person("Ammann", "Simon", "CH", false, true);
			Assert.AreEqual("Simon AMMANN", simon.ToString());
		}

		[Test]
		public void ToString_olympicModeAndCapitalize()
		{
			Person simon = new Person("Ammann", "Simon", "CH", true, true);
			Assert.AreEqual("Simon AMMANN", simon.ToString());
		}

		[Test]
		public void ToString_chineseInNonOlympicNonCapitalize()
		{
			Person yao = new Person("Yao", "Ming", "CHN", false, false);
			Assert.AreEqual("Ming Yao", yao.ToString());
		}

		[Test]
		public void ToString_chineseInOlympicMode()
		{
			Person yao = new Person("Yao", "Ming", "CHN", true, false);
			Assert.AreEqual("Yao Ming", yao.ToString());
		}

		[Test]
		public void ToString_chineseInOlympicModeAndCapitalize()
		{
			Person yao = new Person("Yao", "Ming", "CHN", true, true);
			Assert.AreEqual("YAO Ming", yao.ToString());
		}

	}
}
