using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.WebApp.ViewModel
{
    public class PersonaModel
    {
        

        public int Id { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int Edad { get {

                return this.CalcularEdad();
            } }

        private int CalcularEdad() {
            int edad = DateTime.Now.Year - this.FechaNacimiento.Year;
            return edad;
        }
    }
}
