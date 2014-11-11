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

		protected string GetSurname()
		{
			String surname = _person.FamilyName;
			if (_person.CapitalizeSurname)
			{
				surname = _person.FamilyName.ToUpperInvariant();
			}
			return surname;
		}
	}
}