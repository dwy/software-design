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

		public string NameString(string givenName1, bool isSurnameFirst, bool capitaliseSurname, string surname1)
		{
			_isSurnameFirst = isSurnameFirst;
			_capitaliseSurname = capitaliseSurname;
			String surname = surname1;
			if (capitaliseSurname)
			{
				surname = surname1.ToUpperInvariant();
			}
			if (isSurnameFirst)
				return surname + " " + givenName1;
			
			return givenName1 + " " + surname;
		}
	}
}
