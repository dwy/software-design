using System;

namespace Person
{
	public class PersonNameStrategy
	{
		public static string NameString(string givenName1, bool isSurnameFirst, bool capitaliseSurname, string surname1, PersonNameStrategy s)
		{
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
