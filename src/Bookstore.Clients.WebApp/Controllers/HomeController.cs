using Bookstore.Clients.WebApp.Models;
using Bookstore.Common.Models.WebModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace Bookstore.Clients.WebApp.Controllers
{
	public class HomeController : Controller
	{
		readonly string _baseApiUrl = ConfigurationManager.AppSettings["servicesBaseUrl"];

		public ActionResult Index()
		{
			var viewModel = new LinksViewModel();

			using (var client = new HttpClient { BaseAddress = new Uri(_baseApiUrl) })
			{
				var response = client.GetAsync("").Result;
				if (response.StatusCode == HttpStatusCode.OK)
				{
					viewModel.Links = JsonConvert.DeserializeObject<List<Link>>(response.Content.ReadAsStringAsync().Result);
				}
			}

			return View(viewModel);
		}

		public ActionResult Books()
		{

			return View();
		}

		public ActionResult Users()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}