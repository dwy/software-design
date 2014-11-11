using System;
using System.Collections.Generic;

namespace Person
{
	public static class PersonNameStrategyFactory
	{
		private static readonly List<String> SurnameFirst = new List<String> {"CHN", "KOR"};

		public static PersonNameStrategy Create(string nationality, bool capitalizeSurname, bool olympicMode)
		{
			if (olympicMode)
			{
				return new OlympicPersonNameStrategy(capitalizeSurname, IsSurnameFirst(nationality));
			}

			return new DefaultPersonNameStrategy(capitalizeSurname);
		}

		private static bool IsSurnameFirst(string nationality)
		{
			return SurnameFirst.Contains(nationality);
		}
	}
}