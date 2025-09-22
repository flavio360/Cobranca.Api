using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace Cobranca.Api.Config.Helpers
{
    public class SecurityHelper
    {
        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]

        public class AuthorizeAttribute : Attribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {                
                string apiToken = context.HttpContext.Request.Headers.TryGetValue("Impacto-Api-Token", out StringValues _TokenValue) ? _TokenValue.ToString() : string.Empty;

                if (apiToken != "Token")
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
