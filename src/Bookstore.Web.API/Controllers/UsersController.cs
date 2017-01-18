using Bookstore.Common.Infrastructure.Commands;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Common.Models.WebModels;
using Bookstore.Web.API.Helpers;
using System.Web.Http;

namespace Bookstore.Web.API.Controllers
{
	public class UsersController : ApiController
	{
		private readonly IQueryHandler<GetUserQuery, User> _getUserUseCase;
		private readonly ICommandHandler<RegisterNewUserCommand> _registerUserUseCase;

		public UsersController(
			IQueryHandler<GetUserQuery, User> getUserUseCase,
			ICommandHandler<RegisterNewUserCommand> registerUserUseCase)
		{
			_getUserUseCase = getUserUseCase;
			_registerUserUseCase = registerUserUseCase;
		}

		public void GetUser(int userId)
		{
			if (!Validators.IsIdValid(userId))
				return;

			var query = new GetUserQuery(userId);

			var result = _getUserUseCase.Handle(query);

			if (result != null)
				return;

			return;
		}

		public void SignUp(NewUser newUser)
		{
			if (newUser == null)
				return;

			var command = new RegisterNewUserCommand(newUser);

			if (!command.IsValidCommand())
				return;

			_registerUserUseCase.Handle(command);

			var query = new GetUserQuery(command.Login);

			var createdUser = _getUserUseCase.Handle(query);

			if (createdUser == null)
				return;

			return;
		}
	}
}
