using System;
using System.Collections.Generic;

namespace Person
{
	public class OlympicPersonNameStrategy : PersonNameStrategy
	{
		protected static readonly List<String> NationalitiesWithSurnameFirst = new List<String> {"CHN", "KOR"};

		public OlympicPersonNameStrategy(bool olympicMode, bool capitalizeSurname, string nationality) 
			: base(olympicMode, capitalizeSurname, nationality)
		{
		}

		public override string NameString(string givenName, string familyName)
		{
			var surname = GetSurname(familyName);

			if (IsSurnameFirst(_nationality, _olympicMode))
				return surname + " " + givenName;
			
			return givenName + " " + surname;
		}

		private static bool IsSurnameFirst(string nationality, bool olympicMode)
		{
			if (!olympicMode)
				return false;
			return NationalitiesWithSurnameFirst.Contains(nationality);
		}
	}
}