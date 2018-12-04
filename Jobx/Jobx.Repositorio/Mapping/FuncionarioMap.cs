using FluentNHibernate.Mapping;
using Jobx.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobx.Repositorio.Mapping
{
    public class FuncionarioMap : ClassMap<Funcionario>
    {
        public FuncionarioMap()
        {
            Table("Funcionario");

            Id(f => f.IdFuncionario)
                .Column("IdFuncionario")
                .GeneratedBy.Identity();

            Map(f => f.Nome)
                .Column("Nome")
                .Length(200)
                .Not.Nullable();

            Map(f => f.Matricula)
                .Column("Matricula")
                .Length(20)
                .Not.Nullable();

            Map(f => f.Telefone)
                .Column("Telefone")
                .Length(11)
                .Not.Nullable();

            Map(f => f.DataNascimento)
                .Column("DataNascimento")
                .Not.Nullable();

            Map(f => f.DataCadastro)
                .Column("DataCadastro")
                .Not.Nullable();

            HasMany(f => f.Atividades)
                .KeyColumn("IdFuncionario")
                .Inverse();
        }
    }
}
