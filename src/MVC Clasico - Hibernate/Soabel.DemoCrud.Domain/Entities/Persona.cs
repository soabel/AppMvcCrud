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
        public virtual string Apellidos { get; set; }
        public virtual string Nombres { get; set; }
        public virtual string DNI { get; set; }
        public virtual DateTime FechaNacimiento { get; set; }
        public virtual string Direccion { get; set; }

        [NotMapped]
        public virtual int Edad
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
