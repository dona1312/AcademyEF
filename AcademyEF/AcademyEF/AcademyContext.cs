﻿using System.Data.Entity;
using AcademyEF.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;
using AcademyEF.Migrations;

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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AcademyContext, Configuration>());
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
            .Property(c => c.ID)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
