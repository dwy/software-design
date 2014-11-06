using System;
using System.Collections.Generic;

namespace Person
{
	public class Person
	{
		private String familyName;
		private String givenName;
		private String nationality;
		private bool capitalizeSurname;
		private bool olympicMode;

		private static List<String> surnameFirst = new List<String> {"CHN", "KOR"};

		private PersonNameStrategy _strategy;

		public Person(String familyName, String givenName, String nationality)
			: this(familyName, givenName, nationality, false, false)
		{
		}

		public Person(String familyName, String givenName, String nationality,
			bool olympicMode, bool capitalizeSurname)
		{
			this.familyName = familyName;
			this.givenName = givenName;
			this.nationality = nationality;
			this.capitalizeSurname = capitalizeSurname;
			this.olympicMode = olympicMode;

			_strategy = new PersonNameStrategy();
		}

		public override string ToString()
		{
			return NameString(givenName, olympicMode, nationality, capitalizeSurname, familyName);
		}

		private static String NameString(string givenName, bool olympicMode, string nationality, bool capitalizeSurname, string familyName)
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

		private static bool IsSurnameFirst(string nationality, bool olympicMode)
		{
			if (!olympicMode)
				return false;
			return surnameFirst.Contains(nationality);
		}
	}
}