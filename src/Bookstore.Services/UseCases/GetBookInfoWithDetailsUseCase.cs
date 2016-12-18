using AutoMapper;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Common.Models.DomainModels;
using Bookstore.Common.Models.WebModels;

namespace Bookstore.Services.UseCases
{
	public class GetBookInfoWithDetailsUseCase : IQueryHandler<GetBookQuery, BookInfoWithDetails>
	{
		private readonly IBookRepository _bookRepository;
		private readonly IStoreRepository _storeRepository;

		public GetBookInfoWithDetailsUseCase(IBookRepository bookRepository, IStoreRepository storeRepository)
		{
			_bookRepository = bookRepository;
			_storeRepository = storeRepository;
		}

		public BookInfoWithDetails Handle(GetBookQuery query)
		{
			var entityBook = query.IsIdKnown ? _bookRepository.Get(query.Id) : _bookRepository.Get(query.Isbn);
			BookInfoWithDetails bookInfo = Mapper.Map<BookDetails, BookInfoWithDetails>(entityBook);

			if (entityBook != null)
			{
				var entityStore = _storeRepository.GetByBookId(entityBook.Id);
				Mapper.Map(entityStore, bookInfo);
			}

			return bookInfo;
		}
	}
}