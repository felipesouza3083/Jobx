using Jobx.Entidades;
using Jobx.Repositorio.Contracts;
using Jobx.Repositorio.Security;
using Jobx.Servicos.Models.Usuário;
using Jobx.Servicos.Upload;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Jobx.Servicos.Controllers
{
    [Authorize]
    [RoutePrefix("jobx/usuario")]
    public class UsuarioController : ApiController
    {
        private IUsuarioRepository repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("cadastrarusuario")]
        public HttpResponseMessage Post(UsuarioCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario u = new Usuario();

                    u.Nome = model.Nome;
                    u.Email = model.Email;
                    u.Senha = Criptografia.EncriptarSenhaMD5(model.Senha);
                    u.Perfil = new Perfil();
                    u.Foto = model.Foto;
                    u.Perfil.IdPerfil = model.IdPerfil;

                    repository.Insert(u);

                    return Request.CreateResponse(HttpStatusCode.OK, "Usuário inserido com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                Hashtable erros = new Hashtable();

                foreach (var m in ModelState)
                {
                    if (m.Value.Errors.Count > 0)
                    {
                        erros[m.Key] = m.Value.Errors.Select(e => e.ErrorMessage);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, erros);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("uploadfoto")]
        public async Task<HttpResponseMessage> PostFoto()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            try
            {
                var pasta = HttpContext.Current.Server.MapPath("/Imagens/");
                var provider = new CustomMultipartFormDataStreamProvider(pasta, ".jpg");
                await Request.Content.ReadAsMultipartAsync(provider);
                return Request.CreateResponse(HttpStatusCode.OK, "Upload realizado com sucesso.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.Message);
            }
        }

        [HttpGet]
        [Route("obterdados")]
        public HttpResponseMessage GetData()
        {
            try
            {
                Usuario u = JsonConvert.DeserializeObject<Usuario>(User.Identity.Name);

                UsuarioAutenticadoViewModel model = new UsuarioAutenticadoViewModel();

                model.IdUsuario = u.IdUsuario;
                model.Nome = u.Nome;
                model.Email = u.Email;

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
