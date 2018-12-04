using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobx.Servicos.Models.Atividade
{
    public class AtividadeConsultaViewModel
    {
        public int IdAtividade { get; set; }
        public string Nome { get; set; }
        public DateTime DataAtividade { get; set; }
        public string NomeFuncionario { get; set; }
    }
}