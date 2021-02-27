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
            var conexao = "Server=localhost\\SQLEXPRESS;Database=CursoEFCore;Trusted_Connection=True;persist security info=True;MultipleActiveResultSets=True;";

            optionsBuilder.UseSqlServer(conexao)
            // optionsBuilder.UseSqlServer(conexao, p => p.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))

            // .UseLazyLoadingProxies()
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>().HasQueryFilter(x => !x.Excluido);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

    }
}