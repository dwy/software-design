using System;
using System.Collections.Generic;

namespace Person
{
	public abstract class PersonNameStrategy
	{
		protected Person _person;
		private static List<String> surnameFirst = new List<String> {"CHN", "KOR"};

		public PersonNameStrategy(Person person)
		{
			_person = person;
		}

		public abstract String NameString();

		protected string GetSurname()
		{
			String surname = _person.FamilyName;
			if (_person.CapitalizeSurname)
			{
				surname = _person.FamilyName.ToUpperInvariant();
			}
			return surname;
		}

		protected bool IsSurnameFirst()
		{
			if (!_person.OlympicMode)
				return false;
			return surnameFirst.Contains(_person.Nationality);
		}
	}
}