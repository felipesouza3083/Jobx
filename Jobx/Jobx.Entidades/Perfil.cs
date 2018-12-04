using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobx.Entidades
{
    public class Perfil
    {
        public virtual int IdPerfil { get; set; }
        public virtual string Nome { get; set; }

        public virtual IList<Usuario> Usuarios { get; set; }

        public Perfil()
        {

        }

        public Perfil(int idPerfil, string nome)
        {
            IdPerfil = idPerfil;
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Id do Perfil:{IdPerfil}, Nome: {Nome}";
        }
    }
}
