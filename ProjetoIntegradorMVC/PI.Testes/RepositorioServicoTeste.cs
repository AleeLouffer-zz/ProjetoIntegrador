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
        [Fact]
        public void Deve_retornar_um_servico()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Contexto>()
                .UseInMemoryDatabase(databaseName: "DBTesteServicos")
                .Options;

            using var contexto = new Contexto(options);
            contexto.Database.EnsureDeleted();
            contexto.Database.EnsureCreated();

            contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", "25,00"));
            contexto.SaveChanges();

            var repo = new Repositorio_Servico(contexto);
            var id = 1;
            
            //Act
            var servico = repo.GetServico(id);

            //Assert
            Assert.Equal(id, servico.Id);
        }

        [Fact]
        public void Deve_retornar_uma_lista_de_servicos()
        {
            var options = new DbContextOptionsBuilder<Contexto>()
                .UseInMemoryDatabase(databaseName: "DBTesteServicos")
                .Options;

            using var contexto = new Contexto(options);
            contexto.Database.EnsureDeleted();
            contexto.Database.EnsureCreated();

            contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", "25,00"));
            contexto.Servicos.Add(new Servico("Manicure", "Manicure", "30,00"));
            contexto.SaveChanges();

            var repo = new Repositorio_Servico(contexto);

            var servicos = repo.GetServicos();

            Assert.Equal(2, servicos.Count);
        }

        [Fact]
        public void Deve_adicionar_servicos_ao_banco_de_dados()
        {
            var options = new DbContextOptionsBuilder<Contexto>()
                .UseInMemoryDatabase(databaseName: "DBTesteServicos")
                .Options;

            using var contexto = new Contexto(options);
            contexto.Database.EnsureDeleted();
            contexto.Database.EnsureCreated();

            var repo = new Repositorio_Servico(contexto);

            var servicos = new List<Servico> { new Servico("Corte", "Corte de Cabelo", "25,00"), new Servico("Manicure", "Manicure", "30,00") };

            repo.AddServicos(servicos);

            Assert.Equal(2, servicos.Count);
        }

        [Fact]
        public void Deve_verificar_servicos_existentes()
        {
            var options = new DbContextOptionsBuilder<Contexto>()
                .UseInMemoryDatabase(databaseName: "DBTestesServicos")
                .Options;

            using var contexto = new Contexto(options);
            contexto.Database.EnsureDeleted();
            contexto.Database.EnsureCreated();

            contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", "25,00"));
            contexto.Servicos.Add(new Servico("Manicure", "Manicure", "30,00"));
            contexto.SaveChanges();

            var listaDeServicosExistentes = new List<Servico> { new Servico("Corte", "Corte de Cabelo", "25,00"), new Servico("Manicure", "Manicure", "30,00") };
            var repo = new Repositorio_Servico(contexto);

            var servicoExistente = repo.VerificarServicoExistente(listaDeServicosExistentes[0]);

            Assert.True(servicoExistente);
        }

        [Fact]
        public void Nao_deve_adicionar_servicos_existentes()
        {
            const string mensagemEsperada = "O serviço já existe";

            var options = new DbContextOptionsBuilder<Contexto>()
               .UseInMemoryDatabase(databaseName: "DBTesteFuncionarios")
               .Options;

            using var contexto = new Contexto(options);
            contexto.Database.EnsureDeleted();
            contexto.Database.EnsureCreated();

            contexto.Servicos.Add(new Servico("Corte", "Corte de Cabelo", "25,00"));
            contexto.Servicos.Add(new Servico("Manicure", "Manicure", "30,00"));
            contexto.SaveChanges();

            var listaDeServicosExistentes = new List<Servico> { new Servico("Corte", "Corte de Cabelo", "25,00"), new Servico("Manicure", "Manicure", "30,00") };

            var repo = new Repositorio_Servico(contexto);

            
            void Acao() => repo.AddServicos(listaDeServicosExistentes);

            
            var mensagem = Assert.Throws<DuplicateNameException>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
