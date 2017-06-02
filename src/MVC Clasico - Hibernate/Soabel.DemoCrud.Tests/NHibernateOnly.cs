using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using System.Reflection;
using NHibernate.Cfg.MappingSchema;
using System.Collections.Generic;
using System.Linq;

namespace Soabel.DemoCrud.Tests
{
    [TestClass]
    public class NHibernateOnly
    {
        [TestMethod]
        public void EjecutarConsultaTest()
        {
            Configuration cfg = new Configuration()
                .DataBaseIntegration(db=> {
                    db.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoCrud;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True";
                    db.Dialect<MsSql2012Dialect>();
                });

            var mapper = new ModelMapper();          
            mapper.AddMappings(Assembly.GetExecutingAssembly().ExportedTypes);

            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            cfg.AddMapping(mapping);
            
            IEnumerable<PersonaDemo> lista = new List<PersonaDemo>();
            using (ISessionFactory factory = cfg.BuildSessionFactory())
            using (ISession session = factory.OpenSession())
            //using (ITransaction tx = session.BeginTransaction())
            {
                lista = session.QueryOver<PersonaDemo>().Future();

                var d = lista.ToList();
                //tx.Commit();
            }

        }

        [TestMethod]
        public void InsertarConsultaTest()
        {
            Configuration cfg = new Configuration()
                .DataBaseIntegration(db => {
                    db.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoCrud;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True";
                    db.Dialect<MsSql2012Dialect>();
                });

            PersonaDemo persona = new PersonaDemo() { Apellidos = "Benaute Laiza", Nombres = "Alfredo", Direccion = "ABC", DNI = "43012421", FechaNacimiento = new DateTime(1985, 4, 7) };

            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().ExportedTypes);

            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            cfg.AddMapping(mapping);

            IEnumerable<PersonaDemo> lista = new List<PersonaDemo>();
            using (ISessionFactory factory = cfg.BuildSessionFactory())
            using (ISession session = factory.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {

                session.Save(persona);
                tx.Commit();

                lista = session.QueryOver<PersonaDemo>().Future();

                var d = lista.ToList();
                
            }

        }


    }

    public class PersonaMap: ClassMapping<PersonaDemo> {
        public PersonaMap() {
            this.Table("Persona");
            this.Id(p => p.Id, map=>map.Generator(Generators.Native));            
            this.Property(p => p.Apellidos);
            this.Property(p => p.Nombres);
            this.Property(p => p.DNI);
            this.Property(p => p.FechaNacimiento);
            this.Property(p => p.Direccion);
            
        }
    }

    public class PersonaDemo
    {
        public virtual int Id { get; set; }
        public virtual string Apellidos { get; set; }
        public virtual string Nombres { get; set; }
        public virtual string DNI { get; set; }
        public virtual DateTime FechaNacimiento { get; set; }
        public virtual string Direccion { get; set; }
        
    }
}
