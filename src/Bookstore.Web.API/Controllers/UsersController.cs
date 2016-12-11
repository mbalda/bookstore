using Bookstore.Common.Infrastructure.Commands;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Common.Models.WebModels;
using Bookstore.Web.API.Helpers;
using System;
using System.Linq;
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
		public IHttpActionResult SignUp([FromBody]NewUser newUser)
		{
			if (newUser == null)
				return BadRequest();

			var command = new RegisterNewUserCommand(newUser);

			if (!command.IsValidCommand())
				return BadRequest();

			_registerUserUseCase.Handle(command);

			var query = new GetUserQuery(command.Login);

			var createdUser = _getUserUseCase.Handle(query);

			if (createdUser == null)
				return NotFound();

			var newUserUrl = createdUser.Links.Single(x => x.Rel == "self").Href;
			return Created(newUserUrl, createdUser);
		}

		[HttpDelete]
		[Route("{userId}")]
		public IHttpActionResult DeleteUser([FromUri]int userId)
		{
			throw new NotImplementedException("This method is not implemented in this version of API.");
		}
	}
}
