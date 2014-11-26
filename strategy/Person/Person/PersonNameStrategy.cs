namespace Person
{
	public abstract class PersonNameStrategy
	{
		private readonly bool _capitaliseSurname;
		protected readonly bool _isSurnameFirst;

		protected PersonNameStrategy(bool capitaliseSurname, bool isSurnameFirst)
		{
			_capitaliseSurname = capitaliseSurname;
			_isSurnameFirst = isSurnameFirst;
		}

		protected string GetSurname(string surname)
		{
			if (_capitaliseSurname)
			{
				return surname.ToUpperInvariant();
			}
			return surname;
		}

		public virtual string NameString(string givenName, string surname)
		{
			var familyName = GetSurname(surname);
			if (_isSurnameFirst)
				return familyName + " " + givenName;
			
			return givenName + " " + familyName;
		}
	}
}
