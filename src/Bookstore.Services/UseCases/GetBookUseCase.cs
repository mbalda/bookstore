using AutoMapper;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Common.Models.WebModels;

namespace Bookstore.Services.UseCases
{
	public class GetBookUseCase : IQueryHandler<GetBookQuery>
	{
		private readonly IBookRepository _bookRepository;

		public GetBookUseCase(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public void Handle(GetBookQuery query)
		{
			var entityBook = _bookRepository.Get(query.Id);

			query.SetResult(Mapper.Map<Book>(entityBook));
		}
	}
}