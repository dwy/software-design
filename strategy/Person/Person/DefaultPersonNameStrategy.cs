namespace Person
{
	public class DefaultPersonNameStrategy : PersonNameStrategy
	{
		public DefaultPersonNameStrategy(bool olympicMode, bool capitalizeSurname, string nationality) 
			: base(olympicMode, capitalizeSurname, nationality)
		{
		}
	}
}