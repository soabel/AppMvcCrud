using AutoMapper;
using Soabel.DemoCrud.Domain.Entities;
using Soabel.DemoCrud.WebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soabel.DemoCrud.WebApp.Adapters
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<PersonaModel, Persona>();
            CreateMap<Persona, PersonaModel>();
        }
    }
}
