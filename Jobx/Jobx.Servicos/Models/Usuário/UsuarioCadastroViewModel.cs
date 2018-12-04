using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobx.Servicos.Models.Usuário
{
    public class UsuarioCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        public string Email { get; set; }
        
        public string Foto { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe a confirmarção de senha")]
        [Compare("Senha", ErrorMessage = "Senhas não conferem")]
        public string ConfirmarSenha { get; set; }

        [Required(ErrorMessage = "Informe o perfil")]
        public int IdPerfil { get; set; }
    }
}