using System;
using System.Collections.Generic;

namespace Person
{
	public abstract class PersonNameStrategy
	{
		protected readonly Person _person;
		private bool _capitalizeSurname;

		protected PersonNameStrategy(Person person, bool capitalizeSurname)
		{
			_person = person;
			_capitalizeSurname = capitalizeSurname;
		}

		public abstract string NameString(string givenName, string familyName);

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