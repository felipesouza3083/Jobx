using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobx.Servicos.Models.Perfil
{
    public class PerfilCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome do perfil.")]
        public string Nome { get; set; }
    }
}