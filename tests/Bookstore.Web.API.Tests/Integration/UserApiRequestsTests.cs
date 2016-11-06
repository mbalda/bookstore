using NUnit.Framework;
using Shouldly;

namespace Bookstore.Web.API.Tests.Integration
{
	[TestFixture]
	public class UserApiRequestsTests : ApiRequestsTestsBase
	{

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestMethod1()
		{

			var result = httpClient.GetAsync("users/1")
				.ContinueWith(x => x.ShouldNotBeNull());
		}

		// http://dotnetliberty.com/index.php/2015/12/17/asp-net-5-web-api-integration-testing/
	}
}
