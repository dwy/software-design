using System;
using System.Collections.Generic;

namespace Person
{
	public abstract class PersonNameStrategy
	{
		protected readonly Person _person;
		private bool _capitalizeSurname;

		protected PersonNameStrategy(Person person)
		{
			_person = person;
			_capitalizeSurname = _person.CapitalizeSurname;
		}

		public abstract string NameString(string givenName);

		protected string GetSurname(string familyName)
		{
			String surname = familyName;
			if (_capitalizeSurname)
			{
				surname = familyName.ToUpperInvariant();
			}
			return surname;
		}
	}
}