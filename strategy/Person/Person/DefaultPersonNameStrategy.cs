using System;

namespace Person
{
	public class DefaultPersonNameStrategy : PersonNameStrategy
	{
		public DefaultPersonNameStrategy(Person person) : base(person)
		{
		}

		public override string NameString(string givenName)
		{
			var surname = GetSurname(_person.FamilyName);
			return _person.GivenName + " " + surname;
		}
	}
}