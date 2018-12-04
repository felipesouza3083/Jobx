using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobx.Servicos.Models.Perfil
{
    public class PerfilAtualizaViewModel
    {
        [Required(ErrorMessage = "Informe o Id.")]
        public int IdPerfil { get; set; }

        [Required(ErrorMessage = "Informe o nome do perfil.")]
        public string Nome { get; set; }
    }
}