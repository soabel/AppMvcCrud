using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using Soabel.DemoCrud.Application.Contract;
using Soabel.DemoCrud.Application.Service;
using Soabel.DemoCrud.Domain.Base;
using Soabel.DemoCrud.Domain.Entities;
using Soabel.DemoCrud.Persistence;
using Soabel.DemoCrud.Persistence.EntityFramework;
using Soabel.DemoCrud.Persistence.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.Tests
{
    [TestClass]
    public class ApplicationNHibernateTests
    {

        private IUnitOfWork unitOfWork;
        private IRepository<Persona> repository;
        private IPersonaService service;
        private NHibernateHelperExtend helper;

        [TestInitialize]
        public void Inicializar()
        {
            this.unitOfWork = new NUnitOfWork();
            this.repository = new NRepository<Persona>(this.unitOfWork);
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
