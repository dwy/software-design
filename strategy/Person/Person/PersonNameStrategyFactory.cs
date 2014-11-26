using System;
using System.Collections.Generic;

namespace Person
{
	public static class PersonNameStrategyFactory
	{
		public static PersonNameStrategy Create(bool capitaliseSurname, bool olympicMode, string nationality)
		{
			return olympicMode
				? (PersonNameStrategy)
					new OlympicPersonNameStrategy(capitaliseSurname, olympicMode && new List<String> {"CHN", "KOR"}.Contains(nationality))
				: new DefaultPersonNameStrategy(capitaliseSurname, olympicMode && new List<String> {"CHN", "KOR"}.Contains(nationality));
		}
	}
}