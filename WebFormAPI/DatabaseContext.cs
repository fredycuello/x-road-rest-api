using RestAPI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestApi
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("base") { }

        public DbSet<Patente> Patentes { get; set; }

        public DbSet<InformacionPrevia> InformacionPrevias { get; set; }

        public System.Data.Entity.DbSet<RestAPI.Propiedad> Propiedads { get; set; }

        public System.Data.Entity.DbSet<RestAPI.Persona> Personas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // other code 
            Database.SetInitializer<DatabaseContext>(null);
            // more code here.
        }

        public System.Data.Entity.DbSet<Factibilidad> Factibilidades { get; set; }
    }
}