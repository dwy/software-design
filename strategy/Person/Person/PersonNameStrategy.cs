using System;
using System.Collections.Generic;

namespace Person
{
	public class PersonNameStrategy
	{
		public static List<String> surnameFirst = new List<String> {"CHN", "KOR"};

		public string NameString(string givenName, bool olympicMode, string nationality, bool capitalizeSurname, string familyName)
		{
			String surname = familyName;
			if (capitalizeSurname)
			{
				surname = familyName.ToUpperInvariant();
			}
			if (IsSurnameFirst(nationality, olympicMode))
				return surname + " " + givenName;
			
			return givenName + " " + surname;
		}

		public static bool IsSurnameFirst(string nationality, bool olympicMode)
		{
			if (!olympicMode)
				return false;
			return surnameFirst.Contains(nationality);
		}
	}
}