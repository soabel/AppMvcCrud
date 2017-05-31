using Soabel.DemoCrud.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.Domain.Entities
{
    public class Persona: BaseEntity
    {
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }

        [NotMapped]
        public int Edad
        {
            get
            {
                return this.CalcularEdad();
            }
        }

        private int CalcularEdad()
        {
            int edad = DateTime.Now.Year - this.FechaNacimiento.Year;
            return edad;
        }
    }
}
