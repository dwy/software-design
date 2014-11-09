namespace Person
{
	public class OlympicPersonNameStrategy : PersonNameStrategy
	{
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
	}
}