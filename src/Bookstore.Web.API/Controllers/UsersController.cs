using Bookstore.Common.Infrastructure.Commands;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Common.Models.WebModels;
using Bookstore.Web.API.Helpers;
using System.Web.Http;

namespace Bookstore.Web.API.Controllers
{
	[RoutePrefix("api/users")]
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

		[HttpGet]
		[Route("{userId}")]
		public IHttpActionResult GetUser([FromUri]int userId)
		{
			if (!Validators.IsIdValid(userId))
				return BadRequest();

			var query = new GetUserQuery(userId);

			var result = _getUserUseCase.Handle(query);

			if (result != null)
				return Ok(result);

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

			var result = _getUserUseCase.Handle(query);

			if (result != null)
				return Created("", result);

			return NotFound();
		}
	}
}
