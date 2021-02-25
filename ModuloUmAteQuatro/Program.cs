using Curso.Modulos;

namespace EstudosEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarregamentoLento();

            //CarregamentoExplicito();

            //CarregamentoAdiantado();

            //ScriptGeralDoBancoDeDados();

            //MigracoesJaAplicadas();

            //TodasMigracoes();

            ModuloUmAteQuatro.AplicarMigracaoEmTempodeExecucao();

            //MigracoesPendentes();

            //SqlInjection();

            /* //warmup
            new Curso.Data.ApplicationContext().Departamentos.AsNoTracking().Any();
            _count=0;
            GerenciarEstadoDaConexao(false);
            _count=0;
            GerenciarEstadoDaConexao(true);
            */

            //HealthCheckBancoDeDados();

            //GapDoEnsureCreated();

            //EnsureCreatedAndDeleted();           
        }
    }
}
