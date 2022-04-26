using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Authentication
{
    public class BasicAuthenticationAttribute : AuthorizeAttribute
    {
        public BasicAuthenticationAttribute()
        {
            Policy = "BasicAuthentication";
        }
    }
}
