using Bookstore.Common.Infrastructure.Commands;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using Bookstore.Common.Models.WebModels;
using Bookstore.DataAccess.Database;
using Bookstore.DataAccess.Repositories;
using Bookstore.Services.UseCases;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Collections.Generic;
using System.IO;

namespace Bookstore.Web.API.Configuration
{
	public static class DependencyConfiguration
	{
		public static void Configure()
		{
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

			RegisterDependencies(container);

			container.Verify();

			WebApiConfig.Register(container);
		}

		private static void RegisterDependencies(Container container)
		{
			RegisterDataAccessLayerComponents(container);

			RegisterCommandHandlers(container);
			RegisterQueryHandlers(container);
		}

		private static void RegisterQueryHandlers(Container container)
		{
			container.Register<IQueryHandler<GetUserQuery, User>, GetUserUseCase>();
			container.Register<IQueryHandler<GetBookQuery, BookInfo>, GetBookBaseInfoUseCase>();
			container.Register<IQueryHandler<GetBookQuery, BookInfoWithDetails>, GetBookInfoWithDetailsUseCase>();
			container.Register<IQueryHandler<GetBooksQuery, ICollection<BookInfo>>, GetBooksBaseInfoUseCase>();
			container.Register<IQueryHandler<GetFileForBookQuery, Stream>, GetFileUseCase>();
		}

		private static void RegisterCommandHandlers(Container container)
		{
			container.Register<ICommandHandler<RegisterNewUserCommand>, RegisterNewUserUseCase>();
			container.Register<ICommandHandler<AddNewBookCommand>, AddNewBookToStoreUseCase>();
			container.Register<ICommandHandler<StoreFileCommand>, StoreFileUseCase>();
		}

		private static void RegisterDataAccessLayerComponents(Container container)
		{
			container.Register<BookstoreContext>(Lifestyle.Scoped);
			container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
			container.Register<IBookRepository, BookRepository>(Lifestyle.Scoped);
			container.Register<IStoreRepository, StoreRepository>(Lifestyle.Scoped);
			container.Register<IImageRepository, ImageRepository>(Lifestyle.Scoped);
		}
	}
}
