using Bookstore.Common.Models.WebModels;
using NUnit.Framework;
using Shouldly;
using System.Net;

namespace Bookstore.Web.API.Tests.Integration
{
	[TestFixture]
	public class UserApiRequestsTests : ApiRequestsTestsBase
	{
		[Test]
		public void GetExistingUser_WhenIdOfExistingUserPassed_ReturnsUserData()
		{
			// Given
			const string resourceUrl = "users/1";

			// When
			var user = Get<User>(resourceUrl);

			// Then
			user.ShouldSatisfyAllConditions(
				() => user.ShouldNotBeNull(),
				() => user.StatusCode.ShouldBe(HttpStatusCode.OK),
				() => user.Response.Login.ShouldBe("mbalda"),
				() => user.Response.Email.ShouldBe("mbalda@future-processing.com")
			);
		}

		[Test]
		public void GetExistingUser_WhenWrongIdPassed_ReturnsNoData()
		{
			// Given
			const string resourceUrl = "users/1000";

			// When
			var user = Get<User>(resourceUrl);

			// Then
			user.ShouldSatisfyAllConditions(
				() => user.ShouldNotBeNull(),
				() => user.StatusCode.ShouldBe(HttpStatusCode.NotFound)
			);
		}

		[Test]
		public void GetExistingUser_WhenInvalidIdPassed_ReturnsBadRequestStatusCode()
		{
			// Given
			const string resourceUrl = "users/-1";

			// When
			var user = Get<User>(resourceUrl);

			// Then
			user.ShouldSatisfyAllConditions(
				() => user.ShouldNotBeNull(),
				() => user.StatusCode.ShouldBe(HttpStatusCode.BadRequest)
			);
		}

		[Test]
		public void RegisterNewUser_WhenValidDataSent_ReturnsOkStatusAndUserData()
		{
			// Given
			const string resourceUrl = "users";

			var newUser = new NewUser
			{
				Email = "test@domain.com",
				Login = "testUser"
			};

			// When
			var user = Post<NewUser, User>(resourceUrl, newUser);

			// Then
			user.ShouldSatisfyAllConditions(
				() => user.ShouldNotBeNull(),
				() => user.StatusCode.ShouldBe(HttpStatusCode.Created),
				() => user.Response.Login.ShouldBe("testUser"),
				() => user.Response.Email.ShouldBe("test@domain.com")
			);
		}

		[Test]
		public void RegisterNewUser_WhenInvalidDataSent_ReturnsBadRequestStatus()
		{
			// Given
			const string resourceUrl = "users";

			var newUser = new NewUser();

			// When
			var user = Post<NewUser, User>(resourceUrl, newUser);

			// Then
			user.ShouldSatisfyAllConditions(
				() => user.ShouldNotBeNull(),
				() => user.StatusCode.ShouldBe(HttpStatusCode.BadRequest)
			);
		}

		[Test]
		public void RegisterNewUser_WhenNoDataSent_ReturnsBadRequestStatus()
		{
			// Given
			const string resourceUrl = "users";

			// When
			var user = Post<NewUser, User>(resourceUrl, null);

			// Then
			user.ShouldSatisfyAllConditions(
				() => user.ShouldNotBeNull(),
				() => user.StatusCode.ShouldBe(HttpStatusCode.BadRequest)
			);
		}
	}
}
