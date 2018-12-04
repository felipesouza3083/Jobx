using Jobx.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobx.Repositorio.Contracts
{
    public interface IAtividadeRepository:IBaseRepository<Atividade>
    {
        List<Atividade> ListaAtividadePorFuncionario(int idFuncionario);
    }
}
