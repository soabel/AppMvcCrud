using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.Persistence.NHibernate
{
    public class NHibernateHelperExtend {

        private static Configuration configuration;
        private static ISessionFactory sessionFactory;
        private static Guid key;
        
        public static void Initialize(string connectionString) {
            key = Guid.NewGuid();

            System.Diagnostics.Debug.Print(key.ToString());

            if (configuration == null) {
                configuration = new Configuration();
                configuration.DataBaseIntegration(db => {
                    db.ConnectionString = connectionString;
                    db.Dialect<MsSql2012Dialect>();
                });

                var mapper = new ModelMapper();
                mapper.AddMappings(Assembly.GetExecutingAssembly().ExportedTypes);

                HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                configuration.AddMapping(mapping);
                
            }
            if (sessionFactory == null)
            {
                sessionFactory = configuration.BuildSessionFactory();
            }
        }
        

        public static ISession GetSession()
        {
            if (sessionFactory == null)
                sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

        public static void CloseSession()
        {
            if (sessionFactory != null)
                sessionFactory.Close();
        }

        public static Configuration GetConfiguration() {
            return configuration;
        }

    }
}
