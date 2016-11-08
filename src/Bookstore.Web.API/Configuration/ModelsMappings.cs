using AutoMapper;
using Models = Bookstore.Common.Models;

namespace Bookstore.Web.API.Configuration
{
	public class ModelsMappings
	{
		public static void Configuration()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<Models.WebModels.User, Models.DomainModels.User>();
				cfg.CreateMap<Models.DomainModels.User, Models.WebModels.User>();

				cfg.CreateMap<Models.WebModels.BookInfo, Models.DomainModels.Book>();
				cfg.CreateMap<Models.DomainModels.Book, Models.WebModels.BookInfo>();

				cfg.CreateMap<Models.WebModels.BookInfo, Models.DomainModels.BookInStore>();
				cfg.CreateMap<Models.DomainModels.BookInStore, Models.WebModels.BookInfo>();
			});
		}
	}
}