using System;
using System.Collections.Generic;

namespace Person
{
	public class Person
	{
		private readonly String _familyName;
		private readonly String _givenName;

		private readonly bool _capitaliseSurname;
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
		}

		private bool IsSurnameFirst()
		{
			return _olympicMode && SurnameFirst.Contains(_nationality);
		}

		public override string ToString()
		{
			return NameString();
		}

		private string GetSurname()
		{
			return _capitaliseSurname ? _familyName.ToUpperInvariant() : _familyName;
		}

		private string NameString()
		{
			var familyName = GetSurname();
			if (IsSurnameFirst())
				return familyName + " " + _givenName;
			
			return _givenName + " " + familyName;
		}
	}
}