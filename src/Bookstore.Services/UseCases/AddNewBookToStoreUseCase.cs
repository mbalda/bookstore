using Bookstore.Common.Infrastructure.Commands;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.DomainModels;

namespace Bookstore.Services.UseCases
{
	public class AddNewBookToStoreUseCase : ICommandHandler<AddNewBookCommand>
	{
		private readonly IBookRepository _bookRepository;

		public AddNewBookToStoreUseCase(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public void Handle(AddNewBookCommand command)
		{
			var book = new BookDetails
			{
				Author = command.Author,
				Isbn = command.Isbn,
				Title = command.Title,
				Description = command.Description,
				Pages = command.Pages,
				BookInStore = new BookInStore
				{
					Price = command.Price,
					Discount = command.Discount,
					IsInDiscount = command.Discount > 0,
					IsAvailable = command.Amount > 0,
					Amount = command.Amount
				}
			};

			_bookRepository.Insert(book);
		}
	}
}
