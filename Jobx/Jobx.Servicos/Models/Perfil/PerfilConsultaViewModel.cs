using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobx.Servicos.Models.Perfil
{
    public class PerfilConsultaViewModel
    {
        public int IdPerfil { get; set; }
        public string Nome { get; set; }
    }
}