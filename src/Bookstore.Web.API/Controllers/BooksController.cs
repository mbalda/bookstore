using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Services.UseCases;
using Bookstore.Web.API.Helpers;
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
			if (!Validators.IsIdValid(bookId))
				return BadRequest();

			var query = new GetBookQuery(bookId);

			var result = _getBookUseCase.Handle(query);

			if (result != null)
				return Ok(result);

			return NotFound();
		}

		[HttpGet]
		[Route("{bookId}/details")]
		public IHttpActionResult GetBookDetails([FromUri]int bookId)
		{
			if (!Validators.IsIdValid(bookId))
				return BadRequest();

			var query = new GetBookQuery(bookId);


			// TODO: another use case
			var result = _getBookUseCase.Handle(query);

			if (result != null)
				return Ok(result);

			return NotFound();
		}
	}
}
