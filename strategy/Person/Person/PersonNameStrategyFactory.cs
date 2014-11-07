namespace Person
{
	public class PersonNameStrategyFactory
	{
		public static PersonNameStrategy CreatePersonNameStrategy(string nationality, bool olympicMode, bool capitalizeSurname)
		{
			if (olympicMode)
			{
				return new OlympicPersonNameStrategy(capitalizeSurname, nationality);
			}
			return new DefaultPersonNameStrategy(capitalizeSurname);
		}
	}
}