using Jobx.Entidades;
using Jobx.Repositorio.Contracts;
using Jobx.Repositorio.Util;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobx.Repositorio.Persistence
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public Usuario Find(string email, string senha)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return s.Query<Usuario>()
                        .Where(u => u.Email.Equals(email) && u.Senha.Equals(senha))
                        .First();

            }
        }

        public bool HasEmail(string email)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return s.Query<Usuario>()
                        .Where(u => u.Email.Equals(email))
                        .Count() > 0;
            }
        }
    }
}
