using Microsoft.EntityFrameworkCore;
using PI.Testes.Helpers;
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

        public RepositorioServicoTeste()
        {
            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteServicos");
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);

            _repositorio = new RepositorioServico(_contexto);
        }

        [Fact]
        public void Deve_retornar_um_servico()
        {
            _contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", 25m, Local.Ambos));
            _contexto.SaveChanges();
            var id = 1;
            
            var servico = _repositorio.BuscarPorId(id);

            Assert.Equal(id, servico.Id);
        }

        [Fact]
        public void Deve_retornar_uma_lista_de_servicos()
        { 
            _contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", 25m, Local.ADomicilio));
            _contexto.Servicos.Add(new Servico("Manicure", "Manicure", 30m, Local.Ambos));
            _contexto.SaveChanges();

            var servicos = _repositorio.BuscarTodos();

            Assert.Equal(2, servicos.Count);
        }

        [Fact]
        public void Deve_adicionar_servicos_ao_banco_de_dados()
        {
            var servicos = new List<Servico> { new Servico("Corte", "Corte de Cabelo", 25m, Local.ADomicilio), new Servico("Manicure", "Manicure", 30m, Local.NaEmpresa) };

            _repositorio.AdicionarServicos(servicos);

            Assert.Equal(2, servicos.Count);
        }

        [Fact]
        public void Deve_verificar_servicos_existentes()
        {
            _contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", 25m, Local.NaEmpresa));
            _contexto.Servicos.Add(new Servico("Manicure", "Manicure", 30m, Local.Ambos));
            _contexto.SaveChanges();

            var listaDeServicosExistentes = new List<Servico> { new Servico("Corte", "Corte de Cabelo", 25m, Local.NaEmpresa), new Servico("Manicure", "Manicure", 30m, Local.Ambos) };

            var servicoExistente = _repositorio.VerificarServicoExistente(listaDeServicosExistentes[0]);

            Assert.True(servicoExistente);
        }

        [Fact]
        public void Nao_deve_adicionar_servicos_existentes()
        {
            const string mensagemEsperada = "O serviço já existe";
            _contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", 25m, Local.NaEmpresa));
            _contexto.Servicos.Add(new Servico("Manicure", "Manicure", 30m, Local.Ambos));
            _contexto.SaveChanges();
            var listaDeServicosExistentes = new List<Servico> { new Servico("Corte", "Corte de Cabelo", 25m, Local.NaEmpresa), new Servico("Manicure", "Manicure", 30m, Local.Ambos) };
            
            void Acao() => _repositorio.AdicionarServicos(listaDeServicosExistentes);
            
            var mensagem = Assert.Throws<DuplicateNameException>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
