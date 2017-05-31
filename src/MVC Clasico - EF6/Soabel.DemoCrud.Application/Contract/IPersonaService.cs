using Soabel.DemoCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.Application.Contract
{
    public interface IPersonaService
    {
        void Insertar(Persona persona);
        void Eliminar(int id);
        void Modificar(Persona persona);
        IEnumerable<Persona> ListarTodos();
        Persona Obtener(int id);
    }
}
