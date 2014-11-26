using System;
using System.Collections.Generic;

namespace Person
{
	public class Person
	{
		private readonly String _familyName;
		private readonly String _givenName;

		private readonly PersonNameStrategy _strategy;


		public Person(String familyName, String givenName, String nationality,
			bool olympicMode = false, bool capitalizeSurname = false)
		{
			_familyName = familyName;
			_givenName = givenName;
			_strategy = olympicMode
				? new PersonNameStrategy(capitalizeSurname, olympicMode && new List<String> {"CHN", "KOR"}.Contains(nationality))
				: new DefaultPersonNameStrategy(capitalizeSurname, olympicMode && new List<String> {"CHN", "KOR"}.Contains(nationality));
		}

		public override string ToString()
		{
			return _strategy.NameString(_givenName, _familyName);
		}
	}
}