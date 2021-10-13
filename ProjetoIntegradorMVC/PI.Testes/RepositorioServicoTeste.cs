using Microsoft.EntityFrameworkCore;
using PI.Testes.Helpers;
using ProjetoIntegradorMVC;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PI.Testes
{
    public class RepositorioServicoTeste
    {
        private readonly Contexto _contexto;
        private readonly RepositorioServico _repositorio;
        private readonly BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        private Servico _servico1;
        private Servico _servico2;

        public RepositorioServicoTeste()
        {
            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteServicos");
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);

            _repositorio = new RepositorioServico(_contexto);

            _servico1 = new("Manicure", "Manicure", 30m);
            _servico2 = new("Corte", "Corte de Cabelo", 25m);
        }

        [Fact]
        public void Deve_retornar_um_servico()
        {
            _contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", 25m));
            _contexto.SaveChanges();
            var id = 1;
            
            var servico = _repositorio.BuscarPorId(id);

            Assert.Equal(id, servico.Id);
        }

        [Fact]
        public void Deve_retornar_uma_lista_de_servicos()
        { 
            _contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", 25m));
            _contexto.Servicos.Add(new Servico("Manicure", "Manicure", 30m));
            _contexto.SaveChanges();

            var servicos = _repositorio.BuscarTodos();

            Assert.Equal(2, servicos.Count);
        }

        [Fact]
        public void Deve_adicionar_servicos_ao_banco_de_dados()
        {
            var servicos = new List<Servico> { new Servico("Corte", "Corte de Cabelo", 25m), new Servico("Manicure", "Manicure", 30m) };

            _repositorio.AdicionarServicos(servicos);

            Assert.Equal(2, servicos.Count);
        }
    }
}
