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
    public class AtividadeRepository : BaseRepository<Atividade>, IAtividadeRepository
    {
        public List<Atividade> ListaAtividadePorFuncionario(int idFuncionario)
        {
            using(ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return s.Query<Atividade>()//fazer join
                        .Where(a => a.Funcionario.IdFuncionario == idFuncionario)
                        .ToList();
            }
        }
    }
}
