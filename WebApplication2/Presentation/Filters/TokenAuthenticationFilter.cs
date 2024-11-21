using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication2.Domain.Interfaces;
using WebApplication2.Domain.TokenServer;

namespace WebApplication2.Presentation.Filters
{
    public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenManager = (ITokenManager)context.HttpContext.RequestServices.GetService(typeof(ITokenManager));
            var result = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            
                result = false;
                string token = String.Empty;
            if (result)
            {
                token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;
                if (!tokenManager.VerifyToken(token))
                    result = false;
            }
            if (!result)
            {
                context.ModelState.AddModelError("Unauthorised", "you are not authorized");
            }
            context.Result = new UnauthorizedObjectResult(context.ModelState);
        }
    }
}
