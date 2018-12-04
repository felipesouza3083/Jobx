using System;
using System.Threading.Tasks;
using Jobx.Servicos.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Jobx.Servicos.Startup))]

namespace Jobx.Servicos
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //BearerAuthentication -> autenticação por TOKEN..
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/jobx/token"), //URL
                Provider = new ApplicationAuthProvider(), //classe criada..
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(4),
                AllowInsecureHttp = true //somente token criptografado
            });
        }
    }
}
