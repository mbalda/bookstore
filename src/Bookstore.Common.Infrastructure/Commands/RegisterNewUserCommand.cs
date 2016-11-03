namespace Bookstore.Common.Infrastructure.Commands
{
	public class RegisterNewUserCommand
	{
		public string Login { get; private set; }

		public string Email { get; private set; }

		public RegisterNewUserCommand(string login, string email)
		{
			Login = login;
			Email = email;
		}

		public bool IsValidCommand()
		{
			return !string.IsNullOrEmpty(this.Login) && !string.IsNullOrEmpty(this.Email);
		}
	}
}