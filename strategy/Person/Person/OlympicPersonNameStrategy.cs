using System;
using System.Collections.Generic;

namespace Person
{
	public class OlympicPersonNameStrategy : PersonNameStrategy
	{
		protected static readonly List<String> NationalitiesWithSurnameFirst = new List<String> {"CHN", "KOR"};

		public OlympicPersonNameStrategy(bool capitalizeSurname, string nationality) 
			: base(capitalizeSurname, nationality)
		{
		}

		public override string NameString(string givenName, string familyName)
		{
			var surname = GetSurname(familyName);

			if (IsSurnameFirst(_nationality))
				return surname + " " + givenName;
			
			return givenName + " " + surname;
		}

		private static bool IsSurnameFirst(string nationality)
		{
			return NationalitiesWithSurnameFirst.Contains(nationality);
		}
	}
}