using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.WebModels;

namespace Bookstore.Common.Infrastructure.Commands
{
	public class RegisterNewUserCommand : ICommandValidator
	{
		public string Login { get; }

		public string Email { get; }

		public RegisterNewUserCommand(NewUser userToRegister)
		{
			Login = userToRegister.Login;
			Email = userToRegister.Email;
		}

		public bool IsValidCommand()
		{
			return !string.IsNullOrEmpty(this.Login) && !string.IsNullOrEmpty(this.Email);
		}
	}
}