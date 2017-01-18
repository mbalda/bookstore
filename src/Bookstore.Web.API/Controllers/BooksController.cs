using Bookstore.Common.Infrastructure.Commands;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Common.Models.WebModels;
using Bookstore.Web.API.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;

namespace Bookstore.Web.API.Controllers
{
	public class BooksController : ApiController
	{
		private readonly IQueryHandler<GetBookQuery, BookInfo> _getBookBaseInfoUseCase;
		private readonly IQueryHandler<GetBookQuery, BookInfoWithDetails> _getBookInfoWithDetailsUseCase;
		private readonly IQueryHandler<GetBooksQuery, ICollection<BookInfo>> _getBooksBaseInfoUseCase;
		private readonly IQueryHandler<GetFileForBookQuery, Stream> _getFileUseCase;
		private readonly ICommandHandler<AddNewBookCommand> _addNewBookToStoreUseCase;
		private readonly ICommandHandler<StoreFileCommand> _storeFileUseCase;

		public BooksController(
			IQueryHandler<GetBookQuery, BookInfo> getBookBaseInfoUseCase,
			IQueryHandler<GetBookQuery, BookInfoWithDetails> getBookInfoWithDetailsUseCase,
			IQueryHandler<GetBooksQuery, ICollection<BookInfo>> getBooksBaseInfoUseCase,
			ICommandHandler<AddNewBookCommand> addNewBookToStoreUseCase,
			ICommandHandler<StoreFileCommand> storeFileUseCase,
			IQueryHandler<GetFileForBookQuery, Stream> getFileUseCase)
		{
			_getBookBaseInfoUseCase = getBookBaseInfoUseCase;
			_getBookInfoWithDetailsUseCase = getBookInfoWithDetailsUseCase;
			_getBooksBaseInfoUseCase = getBooksBaseInfoUseCase;
			_addNewBookToStoreUseCase = addNewBookToStoreUseCase;
			_storeFileUseCase = storeFileUseCase;
			_getFileUseCase = getFileUseCase;
		}

		public void GetAllBooksBaseInfo()
		{
			var query = new GetBooksQuery(onlyAvailable: false);

			var result = _getBooksBaseInfoUseCase.Handle(query);

			if (result != null)
				return;
		}


		public void GetBookBaseInfo(int bookId)
		{
			if (!Validators.IsIdValid(bookId))
				return;

			var query = new GetBookQuery(bookId);

			var result = _getBookBaseInfoUseCase.Handle(query);

			if (result != null)
				return;
		}

		public void GetBookDetails(int bookId)
		{
			if (!Validators.IsIdValid(bookId))
				return;

			var query = new GetBookQuery(bookId);

			var result = _getBookInfoWithDetailsUseCase.Handle(query);

			if (result != null)
				return;
		}

		public void AddNewBookToStore(NewBook newBook)
		{
			if (!ModelState.IsValid)
				return;

			var command = new AddNewBookCommand(newBook);

			if (!command.IsValidCommand())
				return;

			_addNewBookToStoreUseCase.Handle(command);

			var query = new GetBookQuery(newBook.Isbn);

			var createdBook = _getBookInfoWithDetailsUseCase.Handle(query);

			if (createdBook == null)
				return;

			return;
		}
	}
}
