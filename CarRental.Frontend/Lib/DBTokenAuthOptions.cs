using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CarRental.Frontend.Lib
{
    public class DBTokenAuthOptions: AuthenticationSchemeOptions
    {
           public const string DefaultScemeName = "DBTokenAuthenticationScheme";
        public string TokenHeaderName { get; set; } = "Authorization";
    }

    public class DBTokenAuthHandler : AuthenticationHandler<DBTokenAuthOptions>
    {
        //private readonly IUserService _userService;

        public DBTokenAuthHandler(IOptionsMonitor<DBTokenAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock) 
        {
            //_userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
           return AuthenticateResult.NoResult();
        }

        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Context.Response.Redirect("/Home/Login");// redirect to your error page
            return Task.CompletedTask;
        }
    }
}