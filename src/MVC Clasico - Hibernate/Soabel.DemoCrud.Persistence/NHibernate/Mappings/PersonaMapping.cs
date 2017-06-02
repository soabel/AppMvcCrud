using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Soabel.DemoCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.Persistence.NHibernate.Mappings
{
    public class PersonaMapping: ClassMapping<Persona>
    {
        public PersonaMapping()
        {
            this.Table("Persona");
            this.Id(p => p.Id, map=>map.Generator(Generators.Native));
            this.Property(p => p.Apellidos);
            this.Property(p => p.Nombres);
            this.Property(p => p.DNI);
            this.Property(p => p.FechaNacimiento);
            this.Property(p => p.Direccion);

        }
    }
}
