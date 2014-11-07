namespace Person
{
	public static class PersonNameStrategyFactory
	{
		public static PersonNameStrategy Create(string nationality, bool olympicMode, bool capitalizeSurname)
		{
			if (olympicMode)
			{
				return new OlympicPersonNameStrategy(capitalizeSurname, nationality);
			}
			return new DefaultPersonNameStrategy(capitalizeSurname);
		}
	}
}