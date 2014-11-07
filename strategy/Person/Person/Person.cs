using System;

namespace Person
{
	public class Person
	{
		private readonly String _familyName;
		private readonly String _givenName;

		private PersonNameStrategy _strategy;

		public Person(String familyName, String givenName, String nationality,
			bool olympicMode = false, bool capitalizeSurname = false)
		{
			_familyName = familyName;
			_givenName = givenName;

			_strategy = CreatePersonNameStrategy(nationality, olympicMode, capitalizeSurname);
		}

		public PersonNameStrategy CreatePersonNameStrategy(string nationality, bool olympicMode, bool capitalizeSurname)
		{
			if (olympicMode)
			{
				return new OlympicPersonNameStrategy(capitalizeSurname, nationality);
			}
			return new DefaultPersonNameStrategy(capitalizeSurname);
		}

		public override string ToString()
		{
			return _strategy.NameString(_givenName, _familyName);
		}
	}
}