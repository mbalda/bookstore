using AutoMapper;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Common.Models.DomainModels;
using Bookstore.Common.Models.WebModels;

namespace Bookstore.Services.UseCases
{
	public class GetBookBaseInfoUseCase : IQueryHandler<GetBookQuery, BookInfo>
	{
		private readonly IBookRepository _bookRepository;
		private readonly IStoreRepository _storeRepository;

		public GetBookBaseInfoUseCase(IBookRepository bookRepository, IStoreRepository storeRepository)
		{
			_bookRepository = bookRepository;
			_storeRepository = storeRepository;
		}

		public BookInfo Handle(GetBookQuery query)
		{
			var entityBook = _bookRepository.Get(query.Id);
			var entityStore = _storeRepository.Get(query.Id);

			BookInfo bookInfo = Mapper.Map<BookDetails, BookInfo>(entityBook);
			Mapper.Map(entityStore, bookInfo);

			return bookInfo;
		}
	}
}