using System;
using System.Collections.Generic;

namespace Person
{
	public class PersonNameStrategy
	{
		private static readonly List<String> NationalitiesWithSurnameFirst = new List<String> {"CHN", "KOR"};
		
		private readonly bool _olympicMode;
		private readonly bool _capitalizeSurname;
		private readonly string _nationality;

		public PersonNameStrategy(bool olympicMode, bool capitalizeSurname, string nationality)
		{
			_olympicMode = olympicMode;
			_capitalizeSurname = capitalizeSurname;
			_nationality = nationality;
		}

		public virtual string NameString(string givenName, string familyName)
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

		protected static bool IsSurnameFirst(string nationality, bool olympicMode)
		{
			if (!olympicMode)
				return false;
			return NationalitiesWithSurnameFirst.Contains(nationality);
		}
	}
}