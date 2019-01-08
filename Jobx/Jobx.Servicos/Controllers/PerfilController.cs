using Jobx.Entidades;
using Jobx.Repositorio.Contracts;
using Jobx.Servicos.Models.Perfil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jobx.Servicos.Controllers
{
    [Authorize]
    [RoutePrefix("jobx/perfil")]
    public class PerfilController : ApiController
    {
        private IPerfilRepository repository;

        public PerfilController(IPerfilRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("cadastrarperfil")]
        public HttpResponseMessage Post(PerfilCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Perfil p = new Perfil();

                    p.Nome = model.Nome;

                    repository.Insert(p);

                    return Request.CreateResponse(HttpStatusCode.OK, "Perfil inserido com sucesso.");
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

        [HttpPut]
        [Route("atualizarperfil")]
        public HttpResponseMessage Put(PerfilAtualizaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Perfil p = new Perfil();

                    p.IdPerfil = model.IdPerfil;
                    p.Nome = model.Nome;

                    repository.Update(p);

                    return Request.CreateResponse(HttpStatusCode.OK, "Perfil inserido com sucesso.");
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

        [HttpDelete]
        [Route("deletarperfil")]
        public HttpResponseMessage Delete(int idPerfil)
        {
            try
            {
                var P = repository.FindById(idPerfil);

                repository.Delete(P);

                return Request.CreateResponse(HttpStatusCode.OK, "Perfil excluído com sucesso.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("listartodosperfis")]
        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            try
            {
                List<PerfilConsultaViewModel> lista = new List<PerfilConsultaViewModel>();

                foreach (var p in repository.FindAll())
                {
                    PerfilConsultaViewModel model = new PerfilConsultaViewModel();

                    model.IdPerfil = p.IdPerfil;
                    model.Nome = p.Nome;

                    lista.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("listarperfilporid")]
        public HttpResponseMessage GetById(int idPerfil)
        {
            try
            {
                PerfilConsultaViewModel model = null;

                var p = repository.FindById(idPerfil);

                if (p != null)
                {
                    model = new PerfilConsultaViewModel();

                    model.IdPerfil = p.IdPerfil;
                    model.Nome = p.Nome;
                }

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
