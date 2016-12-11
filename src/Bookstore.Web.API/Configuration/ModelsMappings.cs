using AutoMapper;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Services.Helpers;
using Models = Bookstore.Common.Models;

namespace Bookstore.Web.API.Configuration
{
	public class ModelsMappings
	{
		private static readonly IUserResourceLinksProvider _userResourceLinksProvider;

		static ModelsMappings()
		{
			_userResourceLinksProvider = new UserResourceLinksProvider();
		}

		public static void Configuration()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<Models.WebModels.User, Models.DomainModels.User>();
				cfg.CreateMap<Models.DomainModels.User, Models.WebModels.User>()
					.ForMember(d => d.Links, m => m.MapFrom(s => _userResourceLinksProvider.GetLinksForUser(s.Id)));

				cfg.CreateMap<Models.WebModels.BookInfo, Models.DomainModels.Book>();
				cfg.CreateMap<Models.DomainModels.Book, Models.WebModels.BookInfo>();
				cfg.CreateMap<Models.WebModels.BookInfo, Models.DomainModels.BookInStore>();
				cfg.CreateMap<Models.DomainModels.BookInStore, Models.WebModels.BookInfo>();

				cfg.CreateMap<Models.WebModels.BookInfoWithDetails, Models.DomainModels.BookInStore>();
				cfg.CreateMap<Models.DomainModels.BookInStore, Models.WebModels.BookInfoWithDetails>();
				cfg.CreateMap<Models.WebModels.BookInfoWithDetails, Models.DomainModels.BookDetails>();
				cfg.CreateMap<Models.DomainModels.BookDetails, Models.WebModels.BookInfoWithDetails>();
			});
		}
	}
}