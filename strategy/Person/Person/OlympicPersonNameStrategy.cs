namespace Person
{
	public class OlympicPersonNameStrategy : PersonNameStrategy
	{
		public OlympicPersonNameStrategy(bool capitaliseSurname, bool isSurnameFirst) : base(capitaliseSurname, isSurnameFirst)
		{
		}

		public override string NameString(string givenName, string surname)
		{
			var familyName = GetSurname(surname);
			if (_isSurnameFirst)
				return familyName + " " + givenName;
			
			return givenName + " " + familyName;
		}
	}
}