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

		public GetUserQuery Handle(GetUserQuery query)
		{
			var entityUser = query.IsUserIdKnown ? _userRepository.Get(query.UserId) : _userRepository.Get(query.Login);
			query.User = Mapper.Map<User>(entityUser);

			return query;
		}
	}
}
