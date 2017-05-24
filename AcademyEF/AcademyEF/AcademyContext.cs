using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyEF.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AcademyEF
{
    class AcademyContext : DbContext
    {
        public AcademyContext()
            : base("AcademyDB")
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
