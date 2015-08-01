using System.Collections.Generic;
using TrueBlood.Models;

namespace TrueBlood.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TrueBlood.Models.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TrueBlood.Models.Contexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var _Cidade = new List<Cidade>
            {
                new Cidade {Estado = "CE", Nome = "FORTALEZA"},
                new Cidade {Estado = "CE", Nome = "SOBRAL"}
            };

            _Cidade.ForEach(s => context.Cidade.AddOrUpdate(p => p.Nome, s));
            context.SaveChanges();

            var _Hospital = new List<Hospital>
            {
                new Hospital { Nome = "SÃO CARLOS"},
                new Hospital { Nome = "FROTINHA PARANGABA"}
            };

            _Hospital.ForEach(s => context.Hospital.AddOrUpdate(p => p.Nome, s));
            context.SaveChanges();



        
            //var _Paciente = new List<Paciente>
            //{
            //    new Paciente{},
            //    new Paciente{},
            //};


            /*
              var students = new List<Student>
            {
                new Student { FirstMidName = "Carson",   LastName = "Alexander", 
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso",    
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Arturo",   LastName = "Anand",     
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Gytis",    LastName = "Barzdukas", 
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Yan",      LastName = "Li",        
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Peggy",    LastName = "Justice",   
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstMidName = "Laura",    LastName = "Norman",    
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Nino",     LastName = "Olivetto",  
                    EnrollmentDate = DateTime.Parse("2005-08-11") }
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();*/


        }
    }
}
