﻿using System;
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

		public override string NameString(string givenName, string familyName)
		{
			var surname = GetSurname(familyName);
			if (_isSurnameFirst)
				return surname + " " + givenName;
			
			return givenName + " " + surname;
		}
	}
}