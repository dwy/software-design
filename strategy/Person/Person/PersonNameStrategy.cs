using System;

namespace Person
{
	public abstract class PersonNameStrategy
	{
		protected readonly Person _person;

		protected PersonNameStrategy(Person person)
		{
			_person = person;
		}

		public abstract String NameString();

		protected string GetSurname(string familyName)
		{
			String surname = familyName;
			if (_person.CapitalizeSurname)
			{
				surname = familyName.ToUpperInvariant();
			}
			return surname;
		}
	}
}