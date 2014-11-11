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
			_strategy = CreateStrategy();
		}

		private PersonNameStrategy CreateStrategy()
		{
			if (OlympicMode)
			{
				return new OlympicPersonNameStrategy(capitalizeSurname, IsSurnameFirst(nationality));
			}

			return new DefaultPersonNameStrategy(capitalizeSurname);
		}

		public string GivenName
		{
			set { givenName = value; }
			get { return givenName; }
		}

		private bool OlympicMode
		{
			set { olympicMode = value; }
			get { return olympicMode; }
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