using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using Soabel.DemoCrud.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Soabel.DemoCrud.Persistence.EntityFramework
{
    public class DemoDatabaseContext: DbContext
    {

        public Guid identificador;

        public DemoDatabaseContext(): base("name=DemoDatabaseConnection") {
            this.identificador = Guid.NewGuid();
        }

        public DemoDatabaseContext(string connectionString) : base(connectionString)
        {
            this.identificador = Guid.NewGuid();
        }

        public DbSet<Persona> Personas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().HasKey(x => x.Id)
                .ToTable("Persona");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
