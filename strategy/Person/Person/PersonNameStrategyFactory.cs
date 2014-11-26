using System;
using System.Collections.Generic;

namespace Person
{
	public static class PersonNameStrategyFactory
	{
		private static readonly List<String> SurnameFirst = new List<String> {"CHN", "KOR"};

		public static PersonNameStrategy Create(bool capitaliseSurname, bool olympicMode, string nationality)
		{
			bool isSurnameFirst = olympicMode && SurnameFirst.Contains(nationality);
			if (olympicMode)
			{
				return new OlympicPersonNameStrategy(capitaliseSurname, isSurnameFirst);
			}
			return new DefaultPersonNameStrategy(capitaliseSurname, isSurnameFirst);
		}
	}
}