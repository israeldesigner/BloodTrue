using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TrueBlood.Models
{
    public class Contexto : DbContext
    {

        public Contexto()
            : base("defaultConexao")
        {

        }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Paciente> Paciente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //*impedinto que as tabeleas ficar no plural no banco*//
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}