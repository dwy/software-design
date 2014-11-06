using System;

namespace Person
{
	public abstract class PersonNameStrategy
	{
		protected readonly bool _capitalizeSurname;
		protected readonly string _nationality;

		public PersonNameStrategy(bool capitalizeSurname, string nationality)
		{
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