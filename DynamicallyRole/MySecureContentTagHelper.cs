using DynamicallyRole.Data;
using DynamicAuthorization.Mvc.Core.Models;
using DynamicAuthorization.Mvc.Core;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DynamicallyRole
{
	[HtmlTargetElement("secure-content")]
	public class MySecureContentTagHelper : SecureContentTagHelper<ApplicationDbContext>
	{
		public MySecureContentTagHelper(
			ApplicationDbContext dbContext,
			DynamicAuthorizationOptions authorizationOptions,
			IRoleAccessStore roleAccessStore
			)
			: base(dbContext, authorizationOptions, roleAccessStore)
		{
		}
	}
}
