namespace Person
{
	public class DefaultPersonNameStrategy : PersonNameStrategy
	{
		public DefaultPersonNameStrategy(bool olympicMode, bool capitalizeSurname, string nationality) 
			: base(olympicMode, capitalizeSurname, nationality)
		{
		}

		public override string NameString(string givenName, string familyName)
		{
			var surname = GetSurname(familyName);

			if (IsSurnameFirst(_nationality, _olympicMode))
				return surname + " " + givenName;
			
			return givenName + " " + surname;
		}
	}
}