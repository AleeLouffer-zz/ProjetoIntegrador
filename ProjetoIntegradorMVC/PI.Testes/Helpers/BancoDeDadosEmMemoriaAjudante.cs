using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models.ContextoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI.Testes.Helpers
{
    class BancoDeDadosEmMemoriaAjudante
    {
        public DbContextOptions<Contexto> CriarOpcoesDeContexto(string nomeDoBanco)
        {
            return new DbContextOptionsBuilder<Contexto>().
                UseInMemoryDatabase(databaseName: nomeDoBanco).
                Options;
        }

        public Contexto CriarContexto(string nomeDoBanco)
        {
            var opcoes = CriarOpcoesDeContexto(nomeDoBanco);

            return new Contexto(opcoes);
        }

        public void ReiniciaOBanco(Contexto contexto)
        {
            contexto.Database.EnsureDeleted();
            contexto.Database.EnsureCreated();
        }
    }
}
