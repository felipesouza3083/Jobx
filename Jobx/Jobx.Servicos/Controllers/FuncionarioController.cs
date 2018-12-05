using Jobx.Entidades;
using Jobx.Repositorio.Contracts;
using Jobx.Servicos.Models.Funcionário;
using Jobx.Servicos.Utils;
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
    [RoutePrefix("jobx/funcionario")]
    public class FuncionarioController : ApiController
    {
        private IFuncionarioRepository repository;

        public FuncionarioController(IFuncionarioRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("cadastrarfuncionario")]
        public HttpResponseMessage Post(FuncionarioCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Funcionario f = new Funcionario();

                    f.Matricula = model.Matricula;
                    f.Nome = model.Nome;
                    f.Telefone = model.Telefone;
                    f.DataNascimento = model.DataNascimento;
                    f.DataCadastro = DateTime.Now;

                    repository.Insert(f);

                    return Request.CreateResponse(HttpStatusCode.OK, "Funcionário cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }

            }
            else
            {
                
                return Request.CreateResponse(HttpStatusCode.BadRequest, ValidationUtil.GetValidationErrors(ModelState));
            }
        }

        [HttpPut]
        [Route("alterarfuncionario")]
        public HttpResponseMessage Put(FuncionarioAtualizaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Funcionario f = new Funcionario();

                    f.IdFuncionario = model.IdFuncionario;
                    f.Matricula = model.Matricula;
                    f.Nome = model.Nome;
                    f.Telefone = model.Telefone;
                    f.DataNascimento = model.DataNascimento;
                    f.DataCadastro = DateTime.Now;

                    repository.Update(f);

                    return Request.CreateResponse(HttpStatusCode.OK, "Funcionário atualizado com sucesso.");
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
        [Route("excluirfuncionario")]
        public HttpResponseMessage Delete(int idFuncionario)
        {
            try
            {
                var f = repository.FindById(idFuncionario);

                repository.Delete(f);

                return Request.CreateResponse(HttpStatusCode.OK, "Funcionário excluído com sucesso!");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("listartodosfuncionarios")]
        public HttpResponseMessage Get()
        {
            try
            {
                List<FuncionarioConsultaViewModel> lista = new List<FuncionarioConsultaViewModel>();

                foreach(var f in repository.FindAll())
                {
                    FuncionarioConsultaViewModel model = new FuncionarioConsultaViewModel();

                    model.IdFuncionario = f.IdFuncionario;
                    model.Matricula = f.Matricula;
                    model.Nome = f.Nome;
                    model.Telefone = f.Telefone;
                    model.DataNascimento = f.DataNascimento;

                    lista.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("listarfuncionarioporid")]
        public HttpResponseMessage GetById(int idFuncionario)
        {
            try
            {
                FuncionarioConsultaViewModel model = null;
                var f = repository.FindById(idFuncionario);

                if (f != null)
                {
                    model = new FuncionarioConsultaViewModel();

                    model.IdFuncionario = f.IdFuncionario;
                    model.Matricula = f.Matricula;
                    model.Nome = f.Nome;
                    model.Telefone = f.Telefone;
                    model.DataNascimento = f.DataNascimento;

                    
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
