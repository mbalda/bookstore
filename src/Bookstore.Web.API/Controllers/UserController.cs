using Bookstore.Common.Infrastructure.Commands;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using System.Web.Http;

namespace Bookstore.Web.API.Controllers
{
	[RoutePrefix("api/users")]
	public class UserController : ApiController
	{
		private readonly IQueryHandler<GetUserQuery> _getUserUseCase;
		private readonly ICommandHandler<RegisterNewUserCommand> _registerUserUseCase;

		public UserController(
			IQueryHandler<GetUserQuery> getUserUseCase,
			ICommandHandler<RegisterNewUserCommand> registerUserUseCase)
		{
			_getUserUseCase = getUserUseCase;
			_registerUserUseCase = registerUserUseCase;
		}

		[HttpGet]
		[Route("{userId}")]
		public IHttpActionResult GetUser([FromUri]int userId)
		{
			if (!GetUserQuery.IsValidUserId(userId))
				return BadRequest();

			var query = new GetUserQuery(userId);

			var response = _getUserUseCase.Handle(query);

			if (response.ContainsUser)
				return Ok(response.User);

			return NotFound();
		}

		[HttpPost]
		[Route("")]
		public IHttpActionResult SignUp([FromBody]RegisterNewUserCommand command)
		{
			if (!command.IsValidCommand())
				return BadRequest();

			_registerUserUseCase.Handle(command);

			var query = new GetUserQuery(command.Login);

			var response = _getUserUseCase.Handle(query);

			if (response.ContainsUser)
				return Created("", response.User);

			return NotFound();
		}
	}
}
