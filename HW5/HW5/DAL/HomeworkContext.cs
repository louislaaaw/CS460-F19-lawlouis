using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HW5.Models;

namespace HW5.DAL
{
    public class HomeworkContext : DbContext
    {
        public HomeworkContext() : base("name=HomeworkDB")
        {
            // Disable code-first migrations.  Default initializer is CreateDatabaseIfNotExists
            // This sets the strategy to use the first time only the DbContext is created
            Database.SetInitializer<HomeworkContext>(null);
        }

        public virtual DbSet<Homework> Homework { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Homework>().ToTable("Homeworks");
        }
    }
    
}