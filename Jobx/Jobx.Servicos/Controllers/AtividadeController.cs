using Jobx.Entidades;
using Jobx.Repositorio.Contracts;
using Jobx.Servicos.Models.Atividade;
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
    [RoutePrefix("jobx/atividade")]
    public class AtividadeController : ApiController
    {
        private IAtividadeRepository repository;

        public AtividadeController(IAtividadeRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("cadastraratividade")]
        public HttpResponseMessage Post(AtividadeCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Atividade a = new Atividade();

                    a.Nome = model.Nome;
                    a.DataAtividade = model.DataAtividade;
                    a.Funcionario = new Funcionario();
                    a.Funcionario.IdFuncionario = model.IdFuncionario;

                    repository.Insert(a);

                    return Request.CreateResponse(HttpStatusCode.OK, "Atividade inserida com sucesso.");
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
        [Route("atualizaratividade")]
        public HttpResponseMessage Put(AtividadeAtualizaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Atividade a = new Atividade();

                    a.IdAtividade = model.IdAtividade;
                    a.Nome = model.Nome;
                    a.DataAtividade = model.DataAtividade;
                    a.Funcionario = new Funcionario();
                    a.Funcionario.IdFuncionario = model.IdFuncionario;

                    repository.Update(a);

                    return Request.CreateResponse(HttpStatusCode.OK, "Atividade atualizada com sucesso.");
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
        [Route("deletaratividade")]
        public HttpResponseMessage Delete(int idAtividade)
        {
            try
            {
                var f = repository.FindById(idAtividade);

                repository.Delete(f);

                return Request.CreateResponse(HttpStatusCode.OK, "Atividade excluída com sucesso.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("listartodasatividades")]
        public HttpResponseMessage Get()
        {
            try
            {
                List<AtividadeConsultaViewModel> lista = new List<AtividadeConsultaViewModel>();

                foreach (var a in repository.FindAll())
                {
                    AtividadeConsultaViewModel model = new AtividadeConsultaViewModel();

                    model.IdAtividade = a.IdAtividade;
                    model.Nome = a.Nome;
                    model.DataAtividade = a.DataAtividade;
                    //acertar
                    model.NomeFuncionario = "teste";

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
        [Route("listartodasatividadesporfuncionario")]
        public HttpResponseMessage GetByFuncionario(int idFuncionario)
        {
            try
            {
                List<AtividadeConsultaViewModel> lista = new List<AtividadeConsultaViewModel>();

                foreach (var a in repository.ListaAtividadePorFuncionario(idFuncionario))
                {
                    AtividadeConsultaViewModel model = new AtividadeConsultaViewModel();

                    model.IdAtividade = a.IdAtividade;
                    model.Nome = a.Nome;
                    model.DataAtividade = a.DataAtividade;
                    //acertar
                    model.NomeFuncionario = "teste";

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
        [Route("listaratividadesporid")]
        public HttpResponseMessage Get(int idAtividade)
        {
            try
            {
                AtividadeConsultaViewModel model = null;

                var a = repository.FindById(idAtividade);

                if (a != null)
                {
                    model = new AtividadeConsultaViewModel();

                    model.IdAtividade = a.IdAtividade;
                    model.Nome = a.Nome;
                    model.DataAtividade = a.DataAtividade;
                    //acertar
                    model.NomeFuncionario = "teste";


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
