using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobx.Entidades
{
    public class Usuario
    {
        public virtual int IdUsuario { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Foto { get; set; }

        public virtual Perfil Perfil { get; set; }

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string nome, string email, string senha, string foto)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            Senha = senha;
            Foto = foto;
        }

        public override string ToString()
        {
            return $"Id do Usuário: {IdUsuario}, Nome: {Nome}";
        }
    }
}
