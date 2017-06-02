using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soabel.DemoCrud.Persistence;
using Soabel.DemoCrud.Domain.Base;
using Soabel.DemoCrud.Domain.Entities;
using System.Data.Entity;
using Soabel.DemoCrud.Persistence.EntityFramework;
using Soabel.DemoCrud.Application.Service;
using Soabel.DemoCrud.Application.Contract;
using System.Linq;

namespace Soabel.DemoCrud.Tests
{
    [TestClass]
    public class ApplicationTest
    {

        private IUnitOfWork unitOfWork;
        private IRepository<Persona> repository;

        private IPersonaService service;

        [TestInitialize]
        public void Inicializar()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DemoDatabaseContext>());

            this.unitOfWork = new UnitOfWork(new DemoDatabaseContext());
            this.repository = new Repository<Persona>(this.unitOfWork);
            this.service = new PersonaService(unitOfWork, repository);
        }

        [TestMethod]
        public void InsertarPersonaTest()
        {
            Persona persona = new Persona() { Id = 0, Apellidos = "Benaute Laiza", Nombres = "Alfredo", Direccion = "ABC", DNI = "43012421", FechaNacimiento = new DateTime(1985, 4, 7) };

            this.service.Insertar(persona);

            var lista = this.service.ListarTodos();

            var d = lista.ToList();

        }

        [TestMethod]
        public void ListarTodosPersonaTest()
        {
            
            var lista = this.service.ListarTodos();

            var d = lista.ToList();
            var r = d;


        }
    }
}
