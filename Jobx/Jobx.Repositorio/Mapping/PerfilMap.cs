using FluentNHibernate.Mapping;
using Jobx.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobx.Repositorio.Mapping
{
    public class PerfilMap: ClassMap<Perfil>
    {
        public PerfilMap()
        {
            Table("Perfil");

            Id(p => p.IdPerfil)
                .Column("IdPerfil")
                .GeneratedBy.Identity();

            Map(p => p.Nome)
                .Column("Nome")
                .Length(50)
                .Not.Nullable();

            HasMany(p => p.Usuarios)
                .KeyColumn("IdPerfil")
                .Inverse();
        }
    }
}
