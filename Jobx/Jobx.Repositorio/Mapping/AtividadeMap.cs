using FluentNHibernate.Mapping;
using Jobx.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobx.Repositorio.Mapping
{
    public class AtividadeMap:ClassMap<Atividade>
    {
        public AtividadeMap()
        {
            Table("Atividade");

            Id(a => a.IdAtividade)
                .Column("IdAtividade")
                .GeneratedBy.Identity();

            Map(a => a.Nome)
                .Column("Nome")
                .Length(100)
                .Not.Nullable();

            Map(a => a.DataAtividade)
                .Column("DataAtividade")
                .Not.Nullable();

            References(a => a.Funcionario)
                .Column("IdFuncionario");
        }
    }
}
