using System;
using System.Collections.Generic;

namespace Person
{
	public class OlympicPersonNameStrategy : PersonNameStrategy
	{
		public static readonly List<String> NationalitiesWithSurnameFirst = new List<String> {"CHN", "KOR"};
		private readonly bool _isSurnameFirst;

		public OlympicPersonNameStrategy(bool capitalizeSurname, bool isSurnameFirst) 
			: base(capitalizeSurname)
		{
			_isSurnameFirst = isSurnameFirst;
		}

		public override string NameString(string givenName, string familyName)
		{
			var surname = GetSurname(familyName);

			if (_isSurnameFirst)
				return surname + " " + givenName;
			
			return givenName + " " + surname;
		}

		public static bool IsSurnameFirst(string nationality)
		{
			return NationalitiesWithSurnameFirst.Contains(nationality);
		}
	}
}