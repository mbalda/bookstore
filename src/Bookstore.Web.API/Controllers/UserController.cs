using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using System.Web.Http;

namespace Bookstore.Web.API.Controllers
{
	[RoutePrefix("api/users")]
	public class UserController : ApiController
	{
		private readonly IQueryHandler<GetUserQuery> _getUserUseCase;

		public UserController(IQueryHandler<GetUserQuery> getUserUseCase)
		{
			_getUserUseCase = getUserUseCase;
		}

		[Route("{userId}")]
		public IHttpActionResult Get([FromUri]GetUserQuery query)
		{
			if (query == null)
				return BadRequest();

			var user = _getUserUseCase.Handle(query).User;

			return Ok(user);
		}
	}
}
