using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Devices.API.Middleware
{
    public class BasicAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        
        public BasicAuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string authHeader = httpContext.Request.Headers["Authorization"];
            if(authHeader != null && authHeader.StartsWith("Basic"))
            {
                 string ecodeUserNameAndPassword = authHeader.Substring("Basic ".Length).Trim();   
                 Encoding encoding = Encoding.GetEncoding("UTF-8");

                 string usernameAndPassword = encoding.GetString(Convert.FromBase64String(ecodeUserNameAndPassword));
                 int index= usernameAndPassword.IndexOf(":");
                 var username = usernameAndPassword.Substring(0,index);
                 var password = usernameAndPassword.Substring(index+1);

                 //Getting the credential that are required to authorize the user
                 string userKey = _configuration.GetValue<string>("AppSettings:AuthUser");
                 string passwordKey = _configuration.GetValue<string>("AppSettings:AuthPassword");

                 if(username.Equals(userKey) && password.Equals(passwordKey))
                 {
                     await _next.Invoke(httpContext);
                 }
                 else
                 {
                     httpContext.Response.StatusCode = 401;
                     return;
                 }
            }
            else
            {
                httpContext.Response.StatusCode = 401;
                return;
            }
        }
        
    }

    //Extension method used to add middleware to the HTTP request pipeline
    public static class BasicAuthenticationMiddlewareExtensions {
        public static IApplicationBuilder UseBasicAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthenticationMiddleware>();
        }
    }
}