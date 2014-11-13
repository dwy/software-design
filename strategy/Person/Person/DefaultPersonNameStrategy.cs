namespace Person
{
	public class DefaultPersonNameStrategy : PersonNameStrategy
	{
		public DefaultPersonNameStrategy(bool capitaliseSurname, bool isSurnameFirst) : base(capitaliseSurname, isSurnameFirst)
		{
		}
	}
}