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

		public string NameString(string givenName1, string surname1)
		{
			String surname = surname1;
			if (_capitaliseSurname)
			{
				surname = surname1.ToUpperInvariant();
			}
			if (_isSurnameFirst)
				return surname + " " + givenName1;
			
			return givenName1 + " " + surname;
		}
	}
}
