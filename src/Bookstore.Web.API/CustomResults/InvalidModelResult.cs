using System.Net;
using System.Net.Http;
using System.Web.Http.ModelBinding;

namespace Bookstore.Web.API.CustomResults
{
	public class InvalidModelResult
	{
		private readonly HttpRequestMessage _requestMessage;
		private readonly HttpStatusCode _statusCode;
		private readonly ModelStateDictionary _modelState;

		public InvalidModelResult()
		{

		}
	}
}