using FluentNHibernate.Mapping;
using Jobx.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobx.Repositorio.Mapping
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario");

            Id(u => u.IdUsuario)
                .Column("IdUsuario")
                .GeneratedBy.Identity();

            Map(u => u.Nome)
                .Column("Nome")
                .Length(200)
                .Not.Nullable();

            Map(u => u.Email)
                .Column("Email")
                .Length(250)
                .Not.Nullable();

            Map(u => u.Senha)
                .Column("Senha")
                .Length(200)
                .Not.Nullable();

            Map(u => u.Foto)
                .Column("Foto")
                .Length(100);

            References(u => u.Perfil)
                .Column("IdPerfil");
        }
    }
}
