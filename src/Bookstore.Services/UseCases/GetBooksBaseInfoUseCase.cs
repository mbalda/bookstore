using AutoMapper;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Common.Models.DomainModels;
using Bookstore.Common.Models.WebModels;
using System.Collections.Generic;

namespace Bookstore.Services.UseCases
{
	public class GetBooksBaseInfoUseCase : IQueryHandler<GetBooksQuery, ICollection<BookInfo>>
	{
		private readonly IBookRepository _bookRepository;
		private readonly IStoreRepository _storeRepository;

		public GetBooksBaseInfoUseCase(IBookRepository bookRepository, IStoreRepository storeRepository)
		{
			_bookRepository = bookRepository;
			_storeRepository = storeRepository;
		}

		public ICollection<BookInfo> Handle(GetBooksQuery query)
		{
			ICollection<BookInfo> books = new List<BookInfo>();
			ICollection<BookInStore> availableBooks;

			if (query.OnlyAvailable)
			{
				availableBooks = _storeRepository.GetAvailableBooks();
			}
			else
			{
				availableBooks = _storeRepository.GetAll();
			}

			foreach (var bookInStore in availableBooks)
			{
				var bookDetails = _bookRepository.Get(bookInStore.Id);

				BookInfo bookInfo = Mapper.Map<BookInStore, BookInfo>(bookInStore);
				Mapper.Map(bookDetails, bookInfo);

				books.Add(bookInfo);
			}

			return books;
		}
	}
}