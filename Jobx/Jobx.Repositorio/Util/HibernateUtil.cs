using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Jobx.Repositorio.Mapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobx.Repositorio.Util
{
    class HibernateUtil
    {
        //atributo
        private static ISessionFactory factory;

        //configurando fabrica de conexoes
        public static ISessionFactory GetSessionFactory()
        {
            //configurar a session factory
            if (factory == null)
            {
                factory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationManager.ConnectionStrings["JOBX"].ConnectionString))
                        .Mappings(m => m.FluentMappings.Add<UsuarioMap>())
                        .Mappings(m => m.FluentMappings.Add<PerfilMap>())
                        .Mappings(m => m.FluentMappings.Add<FuncionarioMap>())
                        .Mappings(m => m.FluentMappings.Add<AtividadeMap>())
                        //.ExposeConfiguration(e => new SchemaExport(e).Execute(true, true, false))
                        .BuildSessionFactory();
            }

            return factory; //retornar o valor do atributo..
        }
    }
}
