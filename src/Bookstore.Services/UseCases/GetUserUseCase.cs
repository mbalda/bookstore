using AutoMapper;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Common.Models.WebModels;

namespace Bookstore.Services.UseCases
{
	public class GetUserUseCase : IQueryHandler<GetUserQuery>
	{
		private readonly IUserRepository _userRepository;

		public GetUserUseCase(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public void Handle(GetUserQuery query)
		{
			var entityUser = query.IsIdKnown ? _userRepository.Get(query.Id) : _userRepository.Get(query.Login);

			query.SetResult(Mapper.Map<User>(entityUser));
		}
	}
}
