﻿using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;

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
			query.User = query.IsUserIdKnown ? _userRepository.Get(query.UserId) : _userRepository.Get(query.Login);

			return query;
		}
	}
}