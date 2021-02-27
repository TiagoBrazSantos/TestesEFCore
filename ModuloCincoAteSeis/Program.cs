using System;
using System.Linq;
using Curso.Modulos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EstudosEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            ModuloQuatroAteSeis.ConsultaViaProcedure();
            //ModuloQuatroAteSeis.ModuloQuatroAteSeis.CriarStoredProcedureDeConsulta();
            //ModuloQuatroAteSeis.InserirDadosViaProcedure();
            //ModuloQuatroAteSeis.CriarStoredProcedure();
            //ModuloQuatroAteSeis.DivisaoDeConsulta();
            //ModuloQuatroAteSeis.EntendendoConsulta1NN1();
            //ModuloQuatroAteSeis.ConsultaComTAG();
            //ModuloQuatroAteSeis.ConsultaInterpolada();
            //ModuloQuatroAteSeis.ConsultaParametrizada();
            //ModuloQuatroAteSeis.ConsultaProjetada();
            //ModuloQuatroAteSeis.IgnoreFiltroGlobal();
            //ModuloQuatroAteSeis.FiltroGlobal();
        }
    }
}
