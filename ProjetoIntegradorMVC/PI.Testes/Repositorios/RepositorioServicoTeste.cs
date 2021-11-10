using Microsoft.EntityFrameworkCore;
using PI.Testes.Helpers;
using ProjetoIntegradorMVC;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PI.Testes.Repositorios
{
    public class RepositorioServicoTeste
    {
        private readonly Contexto _contexto;
        private readonly RepositorioServico _repositorio;
        private readonly BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        private Empresa _empresa;
        private readonly Servico _servico;

        public RepositorioServicoTeste()
        {
            _empresa = new Empresa("Inteligencia LTDA", "Inteligencia", "inteligencia@inteligencia.com.br", "12345", "05389493000117", "79004394");
            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteServicos");
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);
            _repositorio = new RepositorioServico(_contexto);
            _servico = new Servico("Corte", "Corte de Cabelo", 25m, _empresa, Local.NaEmpresa);
        }

        [Fact]
        public void Deve_retornar_um_servico()
        {
            _contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", 25m, _empresa, Local.Ambos));
            _contexto.SaveChanges();
            var id = 1;
            
            var servico = _repositorio.BuscarPorID(id);

            Assert.Equal(id, servico.Id);
        }

        [Fact]
        public void Deve_retornar_uma_lista_de_servicos()
        { 

            _contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", 25m, _empresa, Local.Ambos));
            _contexto.Servicos.Add(new Servico("Manicure", "Manicure", 30m, _empresa, Local.ADomicilio));
            _contexto.SaveChanges();

            var servicos = _repositorio.Buscar();

            Assert.Equal(2, servicos.Count);
        }

        [Fact]
        public void Deve_adicionar_servicos_ao_banco_de_dados()
        {
            var servicos = new List<Servico> { new Servico("Corte", "Corte de Cabelo", 25m, _empresa, Local.ADomicilio), new Servico("Manicure", "Manicure", 30m, _empresa, Local.NaEmpresa) };

            _repositorio.AdicionarServicos(servicos);

            Assert.Equal(2, servicos.Count);
        }
    }
}
