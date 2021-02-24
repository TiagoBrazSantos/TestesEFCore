using System;
using Curso.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Curso.Data {
    public class ApplicationContextCidade : DbContext {
        public ApplicationContextCidade() { }
        public ApplicationContextCidade(DbContextOptions<ApplicationContext> options) : base (options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CursoEFCore;Trusted_Connection=True;persist security info=True;MultipleActiveResultSets=True;pooling=true")
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information);
        }

        public DbSet<Cidade> Cidades { get; set; }

    }
}