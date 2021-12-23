using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CodeProdigee.API.Extensions
{
    public static class AddJwtAuth
    {
        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {

        }

        public static string GetUserIdClaim(this HttpContext httpContext)
        {
            if (httpContext.User is null) return string.Empty;

            return httpContext.User.Claims.Single(u => u.Type == "id").Value;
        }
    }
}
