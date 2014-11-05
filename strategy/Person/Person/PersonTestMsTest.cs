using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Person
{
	[TestClass]
	public class PersonTestMsTest
	{
		[TestMethod]
		public void ToString_defaultMode()
		{
			Person simon = new Person("Ammann", "Simon", "CH");
			Assert.AreEqual("Simon Ammann", simon.ToString());
		}

		[TestMethod]
		public void ToString_olympicModeAndCapitalize()
		{
			Person simon = new Person("Ammann", "Simon", "CH", true, true);
			Assert.AreEqual("Simon AMMANN", simon.ToString());
		}

		[TestMethod]
		public void ToString_chineseInNonOlympicNonCapitalize()
		{
			Person yao = new Person("Yao", "Ming", "CHN", false, false);
			Assert.AreEqual("Ming Yao", yao.ToString());
		}

		[TestMethod]
		public void ToString_chineseInOlympicMode()
		{
			Person yao = new Person("Yao", "Ming", "CHN", true, false);
			Assert.AreEqual("Yao Ming", yao.ToString());
		}

		[TestMethod]
		public void ToString_chineseInOlympicModeAndCapitalize()
		{
			Person yao = new Person("Yao", "Ming", "CHN", true, true);
			Assert.AreEqual("YAO Ming", yao.ToString());
		}
	}
}