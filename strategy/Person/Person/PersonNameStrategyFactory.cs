using System;
using System.Collections.Generic;

namespace Person
{
	public static class PersonNameStrategyFactory
	{
		private static readonly List<String> SurnameFirst = new List<String> {"CHN", "KOR"};

		public static PersonNameStrategy Create(bool capitaliseSurname, bool olympicMode, string nationality)
		{
			bool isSurnameFirst = IsSurnameFirst(nationality, olympicMode);
			if (olympicMode)
			{
				return new OlympicPersonNameStrategy(capitaliseSurname, isSurnameFirst);
			}
			return new DefaultPersonNameStrategy(capitaliseSurname, isSurnameFirst);
		}

		private static bool IsSurnameFirst(string nationality, bool olympicMode)
		{
			if (!olympicMode)
				return false;
			return SurnameFirst.Contains(nationality);
		}
	}
}