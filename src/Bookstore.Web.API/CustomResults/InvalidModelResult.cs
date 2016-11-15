using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Bookstore.Web.API.CustomResults
{
	public class InvalidModelResult : IHttpActionResult
	{
		private readonly HttpRequestMessage _requestMessage;
		private readonly HttpStatusCode _statusCode;
		private readonly ModelStateDictionary _modelState;

		public InvalidModelResult(HttpRequestMessage requestMessage, HttpStatusCode statusCode, ModelStateDictionary modelState)
		{
			_statusCode = statusCode;
			_modelState = modelState;
			_requestMessage = requestMessage;
		}

		public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
		{
			return Task.FromResult(Execute());
		}

		public HttpResponseMessage Execute()
		{
			return _requestMessage.CreateErrorResponse(_statusCode, new HttpError(_modelState, true));
		}
	}
}