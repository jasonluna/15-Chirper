using Chirper.WebApi.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Chirper.WebApi.Infrastructure
{
    // inherits
    public class ChirperAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        // 2 override methods 
        // check login context
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //allow cors specifically for oauth and authenticating users
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" } );
            
                // find user based on username and password in auth repository
                using (var authorizationRepository = new AuthorizationRepository())
                {
                    var user = await authorizationRepository.FindUser(context.UserName, context.Password);

                    // throw error if no user found 
                    if (user == null)
                    {
                        context.SetError("invaild_grant", "username or password is incorrect");

                    }
                    else
                    {
                        // create a token and add some claims - name, role and auth type
                        var token = new ClaimsIdentity(context.Options.AuthenticationType);
                        token.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                        token.AddClaim(new Claim(ClaimTypes.Role, "user"));

                        context.Validated(token);
                    }
                }
            
        }


    }
}