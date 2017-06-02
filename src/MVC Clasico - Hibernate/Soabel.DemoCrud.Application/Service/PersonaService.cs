using Soabel.DemoCrud.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soabel.DemoCrud.Domain.Entities;
using Soabel.DemoCrud.Persistence.EntityFramework;
using Soabel.DemoCrud.Domain.Base;
using Soabel.DemoCrud.Persistence;

namespace Soabel.DemoCrud.Application.Service
{
    public class PersonaService : IPersonaService
    {
        private IRepository<Persona> repositoryPersona;
        private IUnitOfWork unitOfWork;
        public PersonaService(IUnitOfWork unitOfWork,IRepository<Persona> repositoryPersona) {
            this.unitOfWork = unitOfWork;
            this.repositoryPersona = repositoryPersona;
        }
        public void Eliminar(int id)
        {
            var persona = this.repositoryPersona.Query(x=>x.Id==id).FirstOrDefault();

            if (persona != null)
            {

                this.unitOfWork.Commit(() => {
                    this.repositoryPersona.Remove(persona);
                });
                
            }

        }

        public void Insertar(Persona persona)
        {   
            this.unitOfWork.Commit(()=> {
                this.repositoryPersona.Add(persona);
            });
        }

        public IEnumerable<Persona> ListarTodos()
        {
            return this.repositoryPersona.Query().AsEnumerable();
        }

        public void Modificar(Persona persona)
        {
            var personaEditar = this.repositoryPersona.Query().Where(x => x.Id == persona.Id).FirstOrDefault();

            if (personaEditar != null)
            {
                //Mapear
                personaEditar.Apellidos = persona.Apellidos;
                personaEditar.Nombres = persona.Nombres;
                personaEditar.DNI = persona.DNI;
                personaEditar.FechaNacimiento = persona.FechaNacimiento;
                personaEditar.Direccion = persona.Direccion;
                
            }

            this.unitOfWork.Commit(() => {
                this.repositoryPersona.Update(personaEditar);
            });

        }

        public Persona Obtener(int id)
        {
            return this.repositoryPersona.Query().Where(x => x.Id == id).FirstOrDefault();            
        }
    }
}
