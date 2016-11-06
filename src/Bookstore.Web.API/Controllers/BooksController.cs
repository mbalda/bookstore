using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Services.UseCases;
using System.Web.Http;

namespace Bookstore.Web.API.Controllers
{
	[RoutePrefix("api/books")]
	public class BooksController : ApiController
	{
		private readonly GetBookUseCase _getBookUseCase;

		public BooksController(GetBookUseCase getBookUseCase)
		{
			_getBookUseCase = getBookUseCase;
		}

		[HttpGet]
		[Route("{bookId}")]
		public IHttpActionResult GetBookBaseInfo([FromUri]int bookId)
		{
			if (!GetUserQuery.IsValidUserId(bookId))
				return BadRequest();

			var query = new GetBookQuery(bookId);

			_getBookUseCase.Handle(query);

			if (query.ContainsResult)
				return Ok(query.Result);

			return NotFound();
		}
	}
}
