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
		}

		public override string ToString()
		{
			return NameString(givenName, IsSurnameFirst(), capitalizeSurname, familyName);
		}

		private static String NameString(string givenName1, bool isSurnameFirst, bool capitaliseSurname, string surname1)
		{
			String surname = surname1;
			if (capitaliseSurname)
			{
				surname = surname1.ToUpperInvariant();
			}
			if (isSurnameFirst)
				return surname + " " + givenName1;
			
			return givenName1 + " " + surname;
		}

		private bool IsSurnameFirst()
		{
			if (!olympicMode)
				return false;
			return surnameFirst.Contains(nationality);
		}
	}
}