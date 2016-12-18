using Bookstore.Common.Infrastructure.Commands;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Common.Models.WebModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace Bookstore.Web.API.Controllers
{
	[EnableQuery]
	public class BookInfoController : ODataController
	{
		private readonly IQueryHandler<GetBookQuery, BookInfo> _getBookBaseInfoUseCase;
		private readonly IQueryHandler<GetBookQuery, BookInfoWithDetails> _getBookInfoWithDetailsUseCase;
		private readonly IQueryHandler<GetBooksQuery, ICollection<BookInfo>> _getBooksBaseInfoUseCase;
		private readonly ICommandHandler<AddNewBookCommand> _addNewBookToStoreUseCase;
		private readonly ICommandHandler<StoreFileCommand> _storeFileUseCase;

		public BookInfoController(
			IQueryHandler<GetBookQuery, BookInfo> getBookBaseInfoUseCase,
			IQueryHandler<GetBookQuery, BookInfoWithDetails> getBookInfoWithDetailsUseCase,
			IQueryHandler<GetBooksQuery, ICollection<BookInfo>> getBooksBaseInfoUseCase,
			ICommandHandler<AddNewBookCommand> addNewBookToStoreUseCase,
			ICommandHandler<StoreFileCommand> storeFileUseCase)
		{
			_getBookBaseInfoUseCase = getBookBaseInfoUseCase;
			_getBookInfoWithDetailsUseCase = getBookInfoWithDetailsUseCase;
			_getBooksBaseInfoUseCase = getBooksBaseInfoUseCase;
			_addNewBookToStoreUseCase = addNewBookToStoreUseCase;
			_storeFileUseCase = storeFileUseCase;
		}

		[EnableQuery]
		public IHttpActionResult Get()
		{
			var query = new GetBooksQuery(onlyAvailable: false);

			var result = _getBooksBaseInfoUseCase.Handle(query);

			if (result != null)
				return Ok(result.AsQueryable());

			return NotFound();
		}
	}
}
