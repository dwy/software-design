using System;
using System.Collections.Generic;

namespace Person
{
	public class PersonNameStrategy
	{
		public static List<String> surnameFirst = new List<String> {"CHN", "KOR"};
		private bool _olympicMode;
		private bool _capitalizeSurname;
		private string _nationality;

		public PersonNameStrategy(bool olympicMode, bool capitalizeSurname, string nationality)
		{
			_olympicMode = olympicMode;
			_capitalizeSurname = capitalizeSurname;
			_nationality = nationality;
		}

		public string NameString(string givenName, string familyName)
		{
			String surname = familyName;
			if (_capitalizeSurname)
			{
				surname = familyName.ToUpperInvariant();
			}
			if (IsSurnameFirst(_nationality, _olympicMode))
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