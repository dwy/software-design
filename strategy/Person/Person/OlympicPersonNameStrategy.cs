using System;
using System.Collections.Generic;

namespace Person
{
	public class OlympicPersonNameStrategy : PersonNameStrategy

	{
		private static readonly List<String> surnameFirst = new List<String> {"CHN", "KOR"};
		private bool _isSurnameFirst;

		public OlympicPersonNameStrategy(Person person) : base(person)
		{
			_isSurnameFirst = IsSurnameFirst(_person.Nationality);
		}

		public override String NameString()
		{
			var surname = GetSurname(_person.FamilyName);
			var givenName = _person.GivenName;
			if (_isSurnameFirst)
				return surname + " " + givenName;
			
			return givenName + " " + surname;
		}

		private bool IsSurnameFirst(string nationality)
		{
			return surnameFirst.Contains(nationality);
		}
	}
}