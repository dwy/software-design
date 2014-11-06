using System;
using System.Collections.Generic;

namespace Person
{
	public class Person
	{
		private String familyName;
		private String givenName;

		private PersonNameStrategy _strategy;

		public Person(String familyName, String givenName, String nationality)
			: this(familyName, givenName, nationality, false, false)
		{
		}

		public Person(String familyName, String givenName, String nationality,
			bool olympicMode, bool capitalizeSurname)
		{
			this.familyName = familyName;
			this.givenName = givenName;

			if (olympicMode)
			{
				_strategy = new OlympicPersonNameStrategy(capitalizeSurname, nationality);
			}
			else
			{
				_strategy = new DefaultPersonNameStrategy(capitalizeSurname, nationality);
			}
		}

		public override string ToString()
		{
			return _strategy.NameString(givenName, familyName);
		}
	}
}