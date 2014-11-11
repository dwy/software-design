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

		private readonly PersonNameStrategy _strategy;
		public static readonly List<String> SurnameFirst = new List<String> {"CHN", "KOR"};


		public Person(String familyName, String givenName, String nationality,
			bool olympicMode = false, bool capitalizeSurname = false)
		{
			this.familyName = familyName;
			this.givenName = givenName;
			this.nationality = nationality;
			this.capitalizeSurname = capitalizeSurname;
			this.olympicMode = olympicMode;
			_strategy = CreateStrategy(this.nationality, this.capitalizeSurname, this.olympicMode);
		}

		public static PersonNameStrategy CreateStrategy(string nationality, bool capitalizeSurname, bool olympicMode)
		{
			if (olympicMode)
			{
				return new OlympicPersonNameStrategy(capitalizeSurname, IsSurnameFirst(nationality));
			}

			return new DefaultPersonNameStrategy(capitalizeSurname);
		}

		public override string ToString()
		{
			return _strategy.NameString(givenName, familyName);
		}

		public static bool IsSurnameFirst(string nationality)
		{
			return SurnameFirst.Contains(nationality);
		}
	}
}