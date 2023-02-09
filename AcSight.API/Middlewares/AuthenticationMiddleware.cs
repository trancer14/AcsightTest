using AcSight.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace AcSight.API.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context,DataContext dbcontext)
        {
            try
            {
                var endpoint = context.GetEndpoint();
                if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
                {
                    await _next.Invoke(context);
                    return;
                }

                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("Basic"))
                {
                  
                    var claim = context.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
                    var conStr = claim.Value;

                    if (!string.IsNullOrEmpty(conStr)) //check if your credentials are valid    
                    {

                        await _next.Invoke(context);
                    }
                    else
                    {
                        context.Response.StatusCode = 401; //Unauthorized    
                        return;
                    }
                }
                else
                {
                    // no authorization header    
                    context.Response.StatusCode = 401; //Unauthorized    
                    return;
                }
            }
            catch (Exception e)
            {
                // no authorization header    
                context.Response.StatusCode = 400;
                return;
            }
        }
    }
}
