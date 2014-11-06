namespace Person
{
	public class DefaultPersonNameStrategy : PersonNameStrategy
	{
		public DefaultPersonNameStrategy(bool capitalizeSurname, string nationality) 
			: base(capitalizeSurname, nationality)
		{
		}

		public override string NameString(string givenName, string familyName)
		{
			var surname = GetSurname(familyName);
			return givenName + " " + surname;
		}
	}
}