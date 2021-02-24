using System;
using Curso.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Curso.Data {
    public class ApplicationContext : DbContext {
        public ApplicationContext() { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CursoEFCore;Trusted_Connection=True;persist security info=True;MultipleActiveResultSets=True;")
            // .EnableSensitiveDataLogging()
            // .LogTo(Console.WriteLine, LogLevel.Information);
            ;
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

    }
}