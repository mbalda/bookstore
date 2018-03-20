using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Bookstore.Common.Infrastructure.Commands;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Common.Models.WebModels;
using Bookstore.Web.API.CustomResults;
using Bookstore.Web.API.Helpers;

namespace Bookstore.Web.API.Controllers
{
	[RoutePrefix("api/books")]
	public class BooksController : ApiController
	{
		private readonly IQueryHandler<GetBookQuery, BookInfo> _getBookBaseInfoUseCase;
		private readonly IQueryHandler<GetBookQuery, BookInfoWithDetails> _getBookInfoWithDetailsUseCase;
		private readonly IQueryHandler<GetBooksQuery, ICollection<BookInfo>> _getBooksBaseInfoUseCase;
		private readonly IQueryHandler<GetFileForBookQuery, string> _getFileUseCase;
		private readonly ICommandHandler<AddNewBookCommand> _addNewBookToStoreUseCase;
		private readonly ICommandHandler<StoreFileCommand> _storeFileUseCase;

		public BooksController(
			IQueryHandler<GetBookQuery, BookInfo> getBookBaseInfoUseCase,
			IQueryHandler<GetBookQuery, BookInfoWithDetails> getBookInfoWithDetailsUseCase,
			IQueryHandler<GetBooksQuery, ICollection<BookInfo>> getBooksBaseInfoUseCase,
			ICommandHandler<AddNewBookCommand> addNewBookToStoreUseCase,
			ICommandHandler<StoreFileCommand> storeFileUseCase,
			IQueryHandler<GetFileForBookQuery, string> getFileUseCase)
		{
			_getBookBaseInfoUseCase = getBookBaseInfoUseCase;
			_getBookInfoWithDetailsUseCase = getBookInfoWithDetailsUseCase;
			_getBooksBaseInfoUseCase = getBooksBaseInfoUseCase;
			_addNewBookToStoreUseCase = addNewBookToStoreUseCase;
			_storeFileUseCase = storeFileUseCase;
			_getFileUseCase = getFileUseCase;
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAllBooksBaseInfo()
		{
			var query = new GetBooksQuery(onlyAvailable: false);

			var result = _getBooksBaseInfoUseCase.Handle(query);

			if (result != null)
				return Ok(result);

			return NotFound();
		}

		[HttpGet]
		[Route("links")]
		public IHttpActionResult GetLinksForAllBooks()
		{
			var query = new GetBooksQuery(onlyAvailable: false);

			var result = _getBooksBaseInfoUseCase.Handle(query);

			if (result != null)
				return Ok(result.SelectMany(book => book.Links).Where(link => link.Rel == "self"));

			return NotFound();
		}

		[HttpGet]
		[Route("available")]
		public IHttpActionResult GetAvailableBooksBaseInfo()
		{
			var query = new GetBooksQuery(onlyAvailable: true);

			var result = _getBooksBaseInfoUseCase.Handle(query);

			if (result != null)
				return Ok(result);

			return NotFound();
		}

		[HttpGet]
		[Route("{bookId}")]
		public IHttpActionResult GetBookBaseInfo([FromUri]int bookId)
		{
			if (!Validators.IsIdValid(bookId))
				return BadRequest();

			var query = new GetBookQuery(bookId);

			var result = _getBookBaseInfoUseCase.Handle(query);

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

			var result = _getBookInfoWithDetailsUseCase.Handle(query);

			if (result != null)
				return Ok(result);

			return NotFound();
		}

		[HttpPost]
		[Route("")]
		public IHttpActionResult AddNewBookToStore([FromBody]NewBook newBook)
		{
			if (!ModelState.IsValid)
				return new InvalidModelResult(Request, HttpStatusCode.BadRequest, ModelState);

			var command = new AddNewBookCommand(newBook);

			if (!command.IsValidCommand())
				return BadRequest();

			_addNewBookToStoreUseCase.Handle(command);

			var query = new GetBookQuery(newBook.Isbn);

			var result = _getBookInfoWithDetailsUseCase.Handle(query);

			if (result != null)
				return Created(result.Links.First(x => x.Rel == "self").Href, result);

			return NotFound();
		}

		[HttpPost]
		[Route("{bookId}/image")]
		public async Task<IHttpActionResult> UploadImage([FromUri] int bookId)
		{
			if (!Request.Content.IsMimeMultipartContent())
			{
				throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
			}

			var provider = new MultipartMemoryStreamProvider();

			try
			{
				string fileName = String.Empty;
				await Request.Content.ReadAsMultipartAsync(provider);

				foreach (HttpContent content in provider.Contents)
				{
					Stream fileStream = null;

					if (content.Headers.ContentDisposition.Name == "fileUpload")
					{
						// Read fileName and fileContent here
					}

					var command = new StoreFileCommand(fileName, fileStream, bookId);

					if (!command.IsValidCommand())
						return BadRequest();

					_storeFileUseCase.Handle(command);
				}

				return Created("", fileName);
			}
			catch (Exception exception)
			{
				return InternalServerError(exception);
			}
		}

		[HttpGet]
		[Route("{bookId}/image")]
		public HttpResponseMessage DownloadImage([FromUri] int bookId)
		{
			if (!Validators.IsIdValid(bookId))
				return new HttpResponseMessage(HttpStatusCode.BadRequest);

			var query = new GetFileForBookQuery(bookId);

			var file = _getFileUseCase.Handle(query);

			if (file == null)
				return new HttpResponseMessage(HttpStatusCode.NotFound);

			return null;
		}

		[HttpPut]
		[Route("{bookId}")]
		public IHttpActionResult UpdateBook([FromUri]int bookId)
		{
			throw new NotImplementedException("This method is not implemented in this version of API.");
		}
	}
}
