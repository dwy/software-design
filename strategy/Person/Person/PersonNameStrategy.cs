using System;

namespace Person
{
	public abstract class PersonNameStrategy
	{
		protected readonly bool _capitalizeSurname;

		public PersonNameStrategy(bool capitalizeSurname)
		{
			_capitalizeSurname = capitalizeSurname;
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