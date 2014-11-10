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
			var surname = GetSurname();
			if (IsSurnameFirst())
				return surname + " " + _person.GivenName;
			
			return _person.GivenName + " " + surname;
		}
	}
}