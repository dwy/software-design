using System;

namespace Person
{
	public class OlympicPersonNameStrategy : PersonNameStrategy

	{
		public OlympicPersonNameStrategy(Person person) : base(person)
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