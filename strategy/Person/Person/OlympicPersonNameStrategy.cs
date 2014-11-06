namespace Person
{
	public class OlympicPersonNameStrategy : PersonNameStrategy
	{
		public OlympicPersonNameStrategy(bool olympicMode, bool capitalizeSurname, string nationality) 
			: base(olympicMode, capitalizeSurname, nationality)
		{
		}
	}
}