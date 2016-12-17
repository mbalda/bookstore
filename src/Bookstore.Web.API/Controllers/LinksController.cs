using Bookstore.Common.Models.WebModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Bookstore.Web.API.Controllers
{
	[RoutePrefix("api")]
	public class LinksController : ApiController
	{
		[Route("")]
		public IHttpActionResult Get()
		{
			IList<Link> links = new List<Link>();
			var basePath = Request.RequestUri;

			links.Add(
				new Link
				{
					Href = $"{basePath}/books",
					Rel = "books",
					Method = HttpMethod.Get.ToString()
				});

			links.Add(
				new Link
				{
					Href = $"{basePath}/users",
					Rel = "users",
					Method = HttpMethod.Get.ToString()
				});

			return Ok(links);
		}
	}
}