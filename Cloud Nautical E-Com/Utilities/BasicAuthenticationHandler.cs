using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Cloud_Nautical_E_Com_.Utilities
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string DefaultUsername = "abc";
        private const string DefaultPassword = "123";

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
                                          ILoggerFactory logger,
                                          System.Text.Encodings.Web.UrlEncoder encoder,
                                          Microsoft.AspNetCore.Authentication.ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authorizationHeader = Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                return Task.FromResult(AuthenticateResult.Fail("Authorization header missing"));
            }

            if (!authorizationHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid authorization header"));
            }

            var base64Credentials = authorizationHeader.Substring("Basic ".Length).Trim();
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(base64Credentials)).Split(':');

            if (credentials.Length != 2)
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid authorization format"));
            }

            var username = credentials[0];
            var password = credentials[1];

            if (username == DefaultUsername && password == DefaultPassword)
            {
                var claims = new[] {
                new Claim(ClaimTypes.Name, username)
            };
                var identity = new ClaimsIdentity(claims, "Basic");
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, "Basic");

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }

            return Task.FromResult(AuthenticateResult.Fail("Invalid credentials"));
        }
    }
}
