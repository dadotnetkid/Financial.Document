using System;
using System.Text;
using System.Web;
using System.Web.Http;
using FDTS.Web;
using FDTS.Models.Startup;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace FDTS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Authentication.ConfigureAuth(app);
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                Provider = new ApplicationOAuthProvider("self"),
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidAudience = EnvironmentVariables.Website,
                        ValidIssuer = EnvironmentVariables.Website,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EnvironmentVariables.SigningKey)),
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                    },

                });
        }


        public static class EnvironmentVariables
        {
            private static HttpRequest Request => HttpContext.Current.Request;
            //#if DEBUG
            //            public static string Website = Request.Url.Scheme + "://" + Request.Url.Authority + Request?.ApplicationPath?.TrimEnd('/') + "/";
            //#else
            //        public  string Website = "http://localhost:60460";
            //#endif
            public static string Website = Request.Url.Scheme + "://" + Request.Url.Authority + Request?.ApplicationPath?.TrimEnd('/') + "/";
            public static string SigningKey = "E2EED04CCCED91FD8170172FD529DAB9E32D65CEF7A50F9FE8545921135A77B4";

        }
    }
}
