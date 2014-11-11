using System;

namespace Person
{
	public class DefaultPersonNameStrategy : PersonNameStrategy
	{
		public DefaultPersonNameStrategy(Person person, bool capitalizeSurname) : base(person, capitalizeSurname)
		{
		}

		public override string NameString(string givenName, string familyName)
		{
			var surname = GetSurname(familyName);
			return givenName + " " + surname;
		}
	}
}