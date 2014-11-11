namespace Person
{
	public class DefaultPersonNameStrategy : PersonNameStrategy
	{
		public DefaultPersonNameStrategy(bool capitalizeSurname) : base(capitalizeSurname)
		{
		}

		public override string NameString(string givenName, string familyName)
		{
			var surname = GetSurname(familyName);
			return givenName + " " + surname;
		}
	}
}