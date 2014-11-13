using System;

namespace Person
{
	public class PersonNameStrategy
	{
		private bool _capitaliseSurname;
		private bool _isSurnameFirst;

		public PersonNameStrategy()
		{
			
		}

		public PersonNameStrategy(bool capitaliseSurname, bool isSurnameFirst)
		{
			_capitaliseSurname = capitaliseSurname;
			_isSurnameFirst = isSurnameFirst;
		}

		public string NameString(string givenName, string surname)
		{
			var familyName = GetSurname(surname);
			if (_isSurnameFirst)
				return familyName + " " + givenName;
			
			return givenName + " " + familyName;
		}

		private string GetSurname(string surname)
		{
			if (_capitaliseSurname)
			{
				return surname.ToUpperInvariant();
			}
			return surname;
		}
	}
}
