using System;
using System.Collections.Generic;

namespace Person
{
	public class PersonNameStrategy
	{
		private Person _person;
		private static List<String> surnameFirst = new List<String> {"CHN", "KOR"};

		public PersonNameStrategy(Person person)
		{
			_person = person;
		}

		public String NameString()
		{
			String surname = _person.FamilyName;
			if (_person.CapitalizeSurname)
			{
				surname = _person.FamilyName.ToUpperInvariant();
			}
			if (IsSurnameFirst())
				return surname + " " + _person.GivenName;
			
			return _person.GivenName + " " + surname;
		}

		private bool IsSurnameFirst()
		{
			if (!_person.OlympicMode)
				return false;
			return surnameFirst.Contains(_person.Nationality);
		}
	}
}