using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobx.Servicos.Models.Funcionário
{
    public class FuncionarioConsultaViewModel
    {
        public int IdFuncionario { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}