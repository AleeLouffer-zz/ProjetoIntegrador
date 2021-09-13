using Microsoft.EntityFrameworkCore;
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
        private readonly Repositorio_Servico _repo;

        public RepositorioServicoTeste()
        {
            var options = new DbContextOptionsBuilder<Contexto>()
                .UseInMemoryDatabase(databaseName: "DBTesteServicos")
                .Options;

            _contexto = new Contexto(options);
            _contexto.Database.EnsureDeleted();
            _contexto.Database.EnsureCreated();

            _repo = new Repositorio_Servico(_contexto);
        }

        [Fact]
        public void Deve_retornar_um_servico()
        {
            _contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", "25,00"));
            _contexto.SaveChanges();
            var id = 1;
            
            var servico = _repo.GetServico(id);

            Assert.Equal(id, servico.Id);
        }

        [Fact]
        public void Deve_retornar_uma_lista_de_servicos()
        { 
            _contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", "25,00"));
            _contexto.Servicos.Add(new Servico("Manicure", "Manicure", "30,00"));
            _contexto.SaveChanges();

            var servicos = _repo.GetServicos();

            Assert.Equal(2, servicos.Count);
        }

        [Fact]
        public void Deve_adicionar_servicos_ao_banco_de_dados()
        {
            var servicos = new List<Servico> { new Servico("Corte", "Corte de Cabelo", "25,00"), new Servico("Manicure", "Manicure", "30,00") };

            _repo.AddServicos(servicos);

            Assert.Equal(2, servicos.Count);
        }

        [Fact]
        public void Deve_verificar_servicos_existentes()
        {
            _contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", "25,00"));
            _contexto.Servicos.Add(new Servico("Manicure", "Manicure", "30,00"));
            _contexto.SaveChanges();

            var listaDeServicosExistentes = new List<Servico> { new Servico("Corte", "Corte de Cabelo", "25,00"), new Servico("Manicure", "Manicure", "30,00") };

            var servicoExistente = _repo.VerificarServicoExistente(listaDeServicosExistentes[0]);

            Assert.True(servicoExistente);
        }

        [Fact]
        public void Nao_deve_adicionar_servicos_existentes()
        {
            const string mensagemEsperada = "O serviço já existe";

            _contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", "25,00"));
            _contexto.Servicos.Add(new Servico("Manicure", "Manicure", "30,00"));
            _contexto.SaveChanges();

            var listaDeServicosExistentes = new List<Servico> { new Servico("Corte", "Corte de Cabelo", "25,00"), new Servico("Manicure", "Manicure", "30,00") };
            
            void Acao() => _repo.AddServicos(listaDeServicosExistentes);
            
            var mensagem = Assert.Throws<DuplicateNameException>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
