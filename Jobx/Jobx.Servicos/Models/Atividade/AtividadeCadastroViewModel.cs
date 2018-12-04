using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobx.Servicos.Models.Atividade
{
    public class AtividadeCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome da atividade.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a data da atividade.")]
        public DateTime DataAtividade { get; set; }

        [Required(ErrorMessage = "Informe o Id do funcionário da atividade.")]
        public int IdFuncionario { get; set; }
    }
}