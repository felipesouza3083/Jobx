﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobx.Servicos.Models.Usuário
{
    public class UsuarioAutenticadoViewModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}