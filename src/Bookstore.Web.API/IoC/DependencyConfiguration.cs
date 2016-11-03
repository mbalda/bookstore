using Bookstore.Common.Infrastructure.Commands;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using Bookstore.DataAccess.Database;
using Bookstore.DataAccess.Repositories;
using Bookstore.Services.UseCases;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Bookstore.Web.API.IoC
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
			RegisterQueriesHandlers(container);
		}

		private static void RegisterQueriesHandlers(Container container)
		{
			container.Register<IQueryHandler<GetUserQuery>, GetUserUseCase>();
		}

		private static void RegisterCommandHandlers(Container container)
		{
			container.Register<ICommandHandler<RegisterNewUserCommand>, RegisterNewUserUseCase>();
		}

		private static void RegisterDataAccessLayerComponents(Container container)
		{
			container.Register<BookstoreContext>(Lifestyle.Scoped);
			container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
		}
	}
}
