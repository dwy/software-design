using System;
using System.Collections.Generic;

namespace Person
{
	public class Person
	{
		private readonly String _familyName;
		private readonly String _givenName;

		private readonly bool _capitaliseSurname;
		private readonly bool _isSurnameFirst;
		private static readonly List<string> SurnameFirst = new List<String> {"CHN", "KOR"};
		private string _nationality;
		private bool _olympicMode;


		public Person(String familyName, String givenName, String nationality,
			bool olympicMode = false, bool capitalizeSurname = false)
		{
			_familyName = familyName;
			_givenName = givenName;
			_capitaliseSurname = capitalizeSurname;
			_nationality = nationality;
			_olympicMode = olympicMode;
			_isSurnameFirst = IsSurnameFirst(_nationality, _olympicMode);
		}

		private static bool IsSurnameFirst(string nationality, bool olympicMode)
		{
			return olympicMode && SurnameFirst.Contains(nationality);
		}

		public override string ToString()
		{
			return NameString(_givenName, _familyName);
		}

		private string GetSurname(string surname)
		{
			if (_capitaliseSurname)
			{
				return surname.ToUpperInvariant();
			}
			return surname;
		}

		private string NameString(string givenName, string surname)
		{
			var familyName = GetSurname(surname);
			if (_isSurnameFirst)
				return familyName + " " + givenName;
			
			return givenName + " " + familyName;
		}
	}
}