using System;
using System.Collections.Generic;

namespace Person
{
	public class Person
	{
		private String familyName;
		private String givenName;
		private String nationality;
		private bool capitalizeSurname;
		private bool olympicMode;

		private static List<String> surnameFirst = new List<String> {"CHN", "KOR"};
		private PersonNameStrategy _strategy;


		public Person(String familyName, String givenName, String nationality,
			bool olympicMode = false, bool capitalizeSurname = false)
		{
			this.familyName = familyName;
			this.givenName = givenName;
			this.nationality = nationality;
			this.capitalizeSurname = capitalizeSurname;
			this.olympicMode = olympicMode;
			_strategy = CreateStrategy();
		}

		public override string ToString()
		{
			return _strategy.NameString(givenName, familyName);
		}

		private PersonNameStrategy CreateStrategy()
		{
			if (olympicMode)
			{
				return new OlympicPersonNameStrategy(capitalizeSurname, IsSurnameFirst());
			}
			return new DefaultPersonNameStrategy(capitalizeSurname, IsSurnameFirst());
		}

		private bool IsSurnameFirst()
		{
			if (!olympicMode)
				return false;
			return surnameFirst.Contains(nationality);
		}
	}
}