using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Soabel.DemoCrud.Persistence.EntityFramework;
using Soabel.DemoCrud.Domain.Entities;
using Soabel.DemoCrud.Persistence;
using Soabel.DemoCrud.Domain.Base;

namespace Soabel.DemoCrud.Tests
{
    [TestClass]
    public class PersistenceTest
    {

        private IUnitOfWork unit;
        private IRepository<PersonaDemo> repository;

        [TestInitialize]
        public void Inicializar() {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DemoDatabaseContext>());

            this.unit = new UnitOfWork(new DemoDatabaseContext());
            this.repository = new Repository<PersonaDemo>(this.unit);
        }

        [TestMethod]
        public void InsertarPersonaTest()
        {
            //Persona persona = new Persona() { Id = 0, Apellidos = "Benaute Laiza", Nombres = "Alfredo", Direccion = "ABC", DNI = "43012421", FechaNacimiento = new DateTime(1985, 4, 7) };
            //this.repository.Add(persona);

            //this.unit.Commit();


            //var d= this.repository.Query().ToListAsync();

            //var lista = d.Result;
            

        }
    }
}
