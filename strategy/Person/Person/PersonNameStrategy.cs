using System;
using System.Collections.Generic;

namespace Person
{
	public abstract class PersonNameStrategy
	{
		protected readonly bool _olympicMode;
		protected readonly bool _capitalizeSurname;
		protected readonly string _nationality;

		public PersonNameStrategy(bool olympicMode, bool capitalizeSurname, string nationality)
		{
			_olympicMode = olympicMode;
			_capitalizeSurname = capitalizeSurname;
			_nationality = nationality;
		}

		public abstract string NameString(string givenName, string familyName);

		protected string GetSurname(string familyName)
		{
			String surname = familyName;
			if (_capitalizeSurname)
			{
				surname = familyName.ToUpperInvariant();
			}
			return surname;
		}
	}
}