using ApiTask.core.Entities;
using ApiTask.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.Data
{
    public class StudentDbContext:IdentityDbContext
    {

        public StudentDbContext(DbContextOptions<StudentDbContext> options):base(options) { }   

        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Studentconfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
