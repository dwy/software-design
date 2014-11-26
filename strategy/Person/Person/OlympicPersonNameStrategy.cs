namespace Person
{
	public class OlympicPersonNameStrategy : PersonNameStrategy
	{
		public OlympicPersonNameStrategy(bool capitaliseSurname, bool isSurnameFirst) : base(capitaliseSurname, isSurnameFirst)
		{
		}
	}
}