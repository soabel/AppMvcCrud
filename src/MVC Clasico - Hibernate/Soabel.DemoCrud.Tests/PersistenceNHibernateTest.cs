using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using Soabel.DemoCrud.Domain.Base;
using Soabel.DemoCrud.Domain.Entities;
using Soabel.DemoCrud.Persistence;
using Soabel.DemoCrud.Persistence.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.Tests
{
    [TestClass]
    public class PersistenceNHibernateTest
    {
       

        [TestInitialize]
        public void Inicializar()
        {
           
        }

        [TestMethod]
        public void ListarPersonaTest()
        {
            
            ISession session = NHibernateHelperExtend.GetSession();
            IQuery query = session.CreateQuery("FROM Persona");

            var lista = query.Enumerable<PersonaDemo>();

            var d = lista.ToList();

        }

        [TestMethod]
        public void InsertarPersonaTest()
        {

            PersonaDemo persona = new PersonaDemo() { Id = 0, Apellidos = "Benaute Laiza", Nombres = "Alfredo", Direccion = "ABC", DNI = "43012421", FechaNacimiento = new DateTime(1985, 4, 7) };


            ISession session = NHibernateHelperExtend.GetSession();

            session.Save(persona);

            IQuery query = session.CreateQuery("FROM Persona");

            var lista = query.Enumerable<PersonaDemo>();
            var d = lista.ToList();

        }

        [TestMethod]
        public void ModificarPersonaTest()
        {

            ISession session = NHibernateHelperExtend.GetSession();
            using (var t = session.BeginTransaction())
            {
                IQuery query = session.CreateQuery("FROM Persona");

                var lista = query.Enumerable<PersonaDemo>();
                var persona = lista.First();
                
                persona.Nombres = persona.Nombres + Guid.NewGuid().ToString();

                session.Update(persona);

                t.Commit();
            }
            
        }

        [TestMethod]
        public void EliminarPersonaTest()
        {

            ISession session = NHibernateHelperExtend.GetSession();

            using (var t = session.BeginTransaction()) {
                IQuery query = session.CreateQuery("FROM Persona");

                var lista = query.Enumerable<PersonaDemo>();
                var persona = lista.Last();

                persona.Nombres = persona.Nombres + Guid.NewGuid().ToString();

                session.Delete(persona);

                t.Commit();
            }

               
            

        }
    }
}
