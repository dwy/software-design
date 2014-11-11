using System;
using System.Collections.Generic;

namespace Person
{
	public class OlympicPersonNameStrategy : PersonNameStrategy

	{
		private static readonly List<String> surnameFirst = new List<String> {"CHN", "KOR"};

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

		private bool IsSurnameFirst()
		{
			return surnameFirst.Contains(_person.Nationality);
		}
	}
}