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


		public Person(String familyName, String givenName, String nationality)
			: this(familyName, givenName, nationality, false, false)
		{
		}

		public Person(String familyName, String givenName, String nationality,
			bool olympicMode, bool capitalizeSurname)
		{
			_strategy = CreateStrategy();
			this.familyName = familyName;
			this.givenName = givenName;
			this.nationality = nationality;
			this.capitalizeSurname = capitalizeSurname;
			this.olympicMode = olympicMode;
		}

		private PersonNameStrategy CreateStrategy()
		{
			if (OlympicMode)
			{
				return new OlympicPersonNameStrategy(this);
			}

			return new DefaultPersonNameStrategy(this);
		}

		public string FamilyName
		{
			set { familyName = value; }
			get { return familyName; }
		}

		public string GivenName
		{
			set { givenName = value; }
			get { return givenName; }
		}

		public string Nationality
		{
			set { nationality = value; }
			get { return nationality; }
		}

		public bool CapitalizeSurname
		{
			set { capitalizeSurname = value; }
			get { return capitalizeSurname; }
		}

		public bool OlympicMode
		{
			set { olympicMode = value; }
			get { return olympicMode; }
		}

		public override string ToString()
		{
			return _strategy.NameString();
		}
	}
}