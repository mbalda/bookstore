namespace Bookstore.Web.API.Helpers
{
	public class Validators
	{
		public static bool IsIdValid(int id)
		{
			return id > 0;
		}
	}
}