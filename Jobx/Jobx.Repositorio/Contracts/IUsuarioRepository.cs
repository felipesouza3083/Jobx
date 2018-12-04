using Jobx.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobx.Repositorio.Contracts
{
    public interface IUsuarioRepository: IBaseRepository<Usuario>
    {
        Usuario Find(string email, string senha);

        bool HasEmail(string email);
    }
}
