using Jobx.Entidades;
using Jobx.Repositorio.Persistence;
using Jobx.Repositorio.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Jobx.Servicos.Providers
{
    public class ApplicationAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //acessar o repositorio..
            UsuarioRepository rep = new UsuarioRepository();

            //buscando o usuario pelo login e senha..
            Usuario u = rep.Find(context.UserName, Criptografia.EncriptarSenhaMD5(context.Password));

            //se o usuario foi encontrado..
            if (u != null)
            {
                Claim c = new Claim(ClaimTypes.Name, JsonConvert.SerializeObject(u));
                Claim[] autorizacoes = new Claim[] { c };
                ClaimsIdentity id = new ClaimsIdentity(autorizacoes,
                OAuthDefaults.AuthenticationType);
                //gravando a autenticação..
                context.Validated(id);
            }
            return Task.FromResult<object>(null);
        }
    }
}