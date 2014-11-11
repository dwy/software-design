using System;
using System.Collections.Generic;

namespace Person
{
	public class OlympicPersonNameStrategy : PersonNameStrategy

	{
		private readonly bool _isSurnameFirst;

		public OlympicPersonNameStrategy(Person person, bool isSurnameFirst) : base(person)
		{
			_isSurnameFirst = isSurnameFirst;
		}

		public override String NameString()
		{
			var surname = GetSurname(_person.FamilyName);
			var givenName = _person.GivenName;
			if (_isSurnameFirst)
				return surname + " " + givenName;
			
			return givenName + " " + surname;
		}
	}
}