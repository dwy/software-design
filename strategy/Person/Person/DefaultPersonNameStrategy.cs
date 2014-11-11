using System;

namespace Person
{
	public class DefaultPersonNameStrategy : PersonNameStrategy
	{
		public DefaultPersonNameStrategy(Person person) : base(person)
		{
		}

		public override String NameString()
		{
			var surname = GetSurname(_person.FamilyName);
			return _person.GivenName + " " + surname;
		}
	}
}