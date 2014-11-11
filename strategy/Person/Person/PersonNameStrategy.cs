using System;

namespace Person
{
	public abstract class PersonNameStrategy
	{
		private bool _capitalizeSurname;

		protected PersonNameStrategy(bool capitalizeSurname)
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