using System;

namespace Person
{
	public class Person
	{
		private readonly String familyName;
		private readonly String givenName;
		private String nationality;
		private bool capitalizeSurname;
		private bool olympicMode;

		private readonly PersonNameStrategy _strategy;


		public Person(String familyName, String givenName, String nationality,
			bool olympicMode = false, bool capitalizeSurname = false)
		{
			this.familyName = familyName;
			this.givenName = givenName;
			this.nationality = nationality;
			this.capitalizeSurname = capitalizeSurname;
			this.olympicMode = olympicMode;
			_strategy = PersonNameStrategyFactory.Create(this.nationality, this.capitalizeSurname, this.olympicMode);
		}

		public override string ToString()
		{
			return _strategy.NameString(givenName, familyName);
		}
	}
}