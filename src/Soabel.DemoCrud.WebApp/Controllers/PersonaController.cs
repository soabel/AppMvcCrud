using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Soabel.DemoCrud.WebApp.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Soabel.DemoCrud.WebApp.Controllers
{
    public class PersonaController : Controller
    {
        // GET: /<controller>/

        private static IEnumerable<PersonaModel> listado;

        public PersonaController() {
            listado = ListarPersona();
        }

        public IActionResult Index()
        {

            ViewData["Message"] = "Mensaje de personas.";            
            return View(listado);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var persona = listado.Where(x => x.Id == id).First();
            return View(persona);
        }

        [HttpPost]
        public IActionResult Editar(PersonaModel persona)
        {
            this.EditarElemento(persona);
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
            this.AgregarElemento(persona);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            this.EliminarElemento(id);            
            return RedirectToAction("Index");
        }
        
        private static IEnumerable<PersonaModel> ListarPersona() {
            List<PersonaModel> lista = new List<PersonaModel>();

            lista.Add(new PersonaModel() { Id = 1, Apellidos = "Benaute Laiza", Nombres = "Alfredo", DNI = "43012421", FechaNacimiento = new DateTime(1985, 4, 7), Direccion = "JR. GARCIA VILLON 674 - LIMA" });
            lista.Add(new PersonaModel() { Id = 1, Apellidos = "Benaute Laiza", Nombres = "Denisse", DNI = "43012421", FechaNacimiento = new DateTime(1985, 4, 7), Direccion = "JR. GARCIA VILLON 674 - LIMA" });

            return lista;
        }

        private void AgregarElemento(PersonaModel persona) {
            var lista = listado.ToList();
            lista.Add(persona);
            listado = lista;
        }

        private void EditarElemento(PersonaModel persona)
        {
            var lista = listado.ToList();

            var elemento = lista.Where(x => x.Id == persona.Id).First();

            elemento.Apellidos = persona.Apellidos;
            elemento.Nombres = persona.Nombres;
            elemento.DNI = persona.DNI;
            elemento.FechaNacimiento = persona.FechaNacimiento;
            elemento.Direccion = persona.Direccion;

            listado = lista;
        }

        private void EliminarElemento(int id)
        {
            var lista = listado.ToList();

            var elemento=lista.Where(x => x.Id == id).First();

            lista.Remove(elemento);
            
            listado = lista;
        }
    }
}
