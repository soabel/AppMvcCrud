using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Soabel.DemoCrud.WebApp.ViewModel;
using Soabel.DemoCrud.Application.Contract;
using AutoMapper;
using Soabel.DemoCrud.Domain.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Soabel.DemoCrud.WebApp.Controllers
{
    public class PersonaController : Controller
    {
        // GET: /<controller>/
        
        private IPersonaService service;

        public PersonaController(IPersonaService service ) {
            this.service = service;
            
        }

        public IActionResult Index()
        {

            ViewData["Message"] = "Mensaje de personas.";     
            
            var listado= Mapper.Map<IEnumerable<PersonaModel>>(service.ListarTodos());
            return View(listado);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var persona = Mapper.Map<PersonaModel>(service.Obtener(id));
            return View(persona);
        }

        [HttpPost]
        public IActionResult Editar(PersonaModel persona)
        {

            var personaModificar = Mapper.Map<Persona>(persona);

            this.service.Modificar(personaModificar);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Nuevo()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Nuevo( PersonaModel persona)
        {
            var personaInsertar = Mapper.Map<Persona>(persona);
            this.service.Insertar(personaInsertar);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            this.service.Eliminar(id);
            return RedirectToAction("Index");
        }
       
    }
}
