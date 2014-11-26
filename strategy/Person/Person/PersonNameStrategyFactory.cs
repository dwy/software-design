using System;
using System.Collections.Generic;

namespace Person
{
	public static class PersonNameStrategyFactory
	{
		private static readonly List<String> SurnameFirst = new List<String> {"CHN", "KOR"};

		public static PersonNameStrategy Create(bool capitaliseSurname, bool olympicMode, string nationality)
		{
			return olympicMode
				? (PersonNameStrategy)
					new OlympicPersonNameStrategy(capitaliseSurname, olympicMode && SurnameFirst.Contains(nationality))
				: new DefaultPersonNameStrategy(capitaliseSurname, olympicMode && SurnameFirst.Contains(nationality));
		}
	}
}