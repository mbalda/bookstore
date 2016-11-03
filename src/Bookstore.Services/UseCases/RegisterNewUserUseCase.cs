using Bookstore.Common.Infrastructure.Commands;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.DomainModels;

namespace Bookstore.Services.UseCases
{
	public class RegisterNewUserUseCase : ICommandHandler<RegisterNewUserCommand>
	{
		private readonly IUserRepository _userRepository;

		public RegisterNewUserUseCase(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public void Handle(RegisterNewUserCommand command)
		{
			_userRepository.Insert(new User
			{
				Login = command.Login,
				Email = command.Email
			});
		}
	}
}
