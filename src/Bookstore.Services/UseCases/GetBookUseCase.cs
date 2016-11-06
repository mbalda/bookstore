using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;

namespace Bookstore.Services.UseCases
{
	public class GetBookUseCase : IQueryHandler<GetBookQuery>
	{
		public void Handle(GetBookQuery query)
		{
		}
	}
}