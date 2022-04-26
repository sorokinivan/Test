using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using WebApplication1.Models;

namespace WebApplication1.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private Settings _settings;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IOptions<Settings> settings
            )
    : base(options, logger, encoder, clock)
        {
            _settings = settings.Value;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Response.Headers.Add("WWW-Authenticate", "Basic");

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail(new AuthenticationException()));
            }

            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var authHeaderRegex = new Regex(@"Basic (.*)");

            if (!authHeaderRegex.IsMatch(authorizationHeader))
            {
                return Task.FromResult(AuthenticateResult.Fail(new AuthenticationException()));
            }

            var base64Auth = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderRegex.Replace(authorizationHeader, "$1")));
            var splittedAuth = base64Auth.Split(Convert.ToChar(":"), 2);

            if(splittedAuth.Length != 2)
            {
                return Task.FromResult(AuthenticateResult.Fail(new AuthenticationException()));
            }

            var username = splittedAuth[0];
            var password = splittedAuth[1];

            if (username != _settings.Username || password != _settings.Password)
            {
                return Task.FromResult(AuthenticateResult.Fail(new AuthenticationException()));
            }

            var authenticatedUser = new User("BasicAuthentication", true, _settings.Username);
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(authenticatedUser));

            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
        }
    }
}
