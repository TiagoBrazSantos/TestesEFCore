using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EstudosEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            HealthCheckBancoDeDados();



            // GapDoEnsureCreated();
        }

        static void TestarConsultaGerenciandoEstadoConexao()
        {
            //warmup
            new Curso.Data.ApplicationContext().Departamentos.AsNoTracking().Any();
            GerenciarEstadoConexao(false);
            GerenciarEstadoConexao(true);
        }
        static void GerenciarEstadoConexao(bool gerenciar)
        {
            var countConnection = 0;

            using var db = new Curso.Data.ApplicationContext();
            var time = System.Diagnostics.Stopwatch.StartNew();

            var conexao = db.Database.GetDbConnection();

            conexao.StateChange += (_, __) => ++countConnection;

            if (gerenciar)
            {
                conexao.Open();
            }

            for (int i = 0; i < 10000; i++)
            {
                db.Departamentos.AsNoTracking().Any();
            }

            if (gerenciar)
            {
                conexao.Close();
            }

            time.Stop();

            var mensagem = $"({(gerenciar ? "Gerenciando" : "Não gerenciando")}) Tempo: {time.Elapsed.ToString()}, {countConnection}";

            Console.WriteLine(mensagem);
        }

        static void HealthCheckBancoDeDados()
        {
            using var db = new Curso.Data.ApplicationContext();
            var canConnect = db.Database.CanConnect();

            if (canConnect)
            {
                Console.WriteLine("Possui conexão com o banco de dados!");
            }
            else
            {
                Console.WriteLine("Não possui conexão com o banco de dados!");
            }
        }

        static void EnsureCreatedAndDeleted()
        {
            using var db = new Curso.Data.ApplicationContext();
            db.Database.EnsureDeleted();
        }

        static void GapDoEnsureCreated()
        {
            using var db = new Curso.Data.ApplicationContext();
            using var dbCidade = new Curso.Data.ApplicationContextCidade();

            db.Database.EnsureCreated();
            dbCidade.Database.EnsureCreated();

            var databaseCreator = dbCidade.GetService<IRelationalDatabaseCreator>();

            databaseCreator.CreateTables();
        }
    }
}
