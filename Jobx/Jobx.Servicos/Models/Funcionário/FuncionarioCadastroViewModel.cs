using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobx.Servicos.Models.Funcionário
{
    public class FuncionarioCadastroViewModel
    {
        [Required(ErrorMessage ="Informe a Matricula do funcionário.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Informe o nome do funcionário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o telefone do funcionário.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe a Data de nascimento do funcionário.")]
        public DateTime DataNascimento { get; set; }
    }
}