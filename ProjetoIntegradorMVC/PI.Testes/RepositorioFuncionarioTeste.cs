using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Xunit;

namespace PI.Testes
{
    public class RepositorioFuncionarioTeste
    {
        [Fact]
        public void Deve_retornar_funcionarios_pelas_ids()
        {
            var options = new DbContextOptionsBuilder<Contexto>()
                .UseInMemoryDatabase(databaseName: "ContextoTesteDB")
                .Options;

            using (var contexto = new Contexto(options))
            {
                contexto.Database.EnsureDeleted();
                contexto.Database.EnsureCreated();
                //Arrange
                contexto.Funcionarios.Add(new Funcionario("Cleide", "111.111.111-11"));
                contexto.Funcionarios.Add(new Funcionario("Ravona", "222.222.222-22"));
                contexto.SaveChanges();

                var repo = new Repositorio_Funcionario(contexto);

                var ids = new List<int>() { 1, 2 };
                //Act
                var funcionarios = repo.GetFuncionarios(ids);

                //Assert
                Assert.Equal(ids[1], funcionarios[1].Id);
            }
        }

        [Fact]
        public void Deve_adicionar_os_funcionarios()
        {
            var options = new DbContextOptionsBuilder<Contexto>()
               .UseInMemoryDatabase(databaseName: "ContextoTeste")
               .Options;

            using (var contexto = new Contexto(options))
            {
                contexto.Database.EnsureDeleted();
                contexto.Database.EnsureCreated();
                var listaFuncionarios = new List<Funcionario> { new Funcionario("Cleido", "131.111.111-11"), new Funcionario("Ravon", "422.222.222-22") };

                var repo = new Repositorio_Funcionario(contexto);

                //Act
                repo.AddFuncionarios(listaFuncionarios);

                //Assert
                Assert.Equal(4, contexto.Funcionarios.Count()) ;
            }
        }

        [Fact]
        public void Deve_verificar_funcionario_existente()
        {
            var options = new DbContextOptionsBuilder<Contexto>()
               .UseInMemoryDatabase(databaseName: "ContextoTesteDB")
               .Options;

            using (var contexto = new Contexto(options))
            {
                contexto.Database.EnsureDeleted();
                contexto.Database.EnsureCreated();
                contexto.Funcionarios.Add(new Funcionario("Cleide", "111.111.111-11"));
                contexto.Funcionarios.Add(new Funcionario("Ravona", "222.222.222-22"));
                contexto.SaveChanges();

                var listaFuncionariosExistentes = new List<Funcionario> { new Funcionario("Cleide", "111.111.111-11"), new Funcionario("Ravona", "222.222.222-22") };

                var repo = new Repositorio_Funcionario(contexto);

                var funcionariosExistentes = repo.VerificarFuncionariosExistentes(listaFuncionariosExistentes[0]);

                Assert.True(funcionariosExistentes);
            }
        }

        [Fact]
        public void Nao_deve_adicionar_funcionario_existente()
        {
            const string mensagemEsperada = "O funcionário já existe";

            var options = new DbContextOptionsBuilder<Contexto>()
               .UseInMemoryDatabase(databaseName: "ContextoTesteDB")
               .Options;

            using (var contexto = new Contexto(options))
            {
                contexto.Database.EnsureDeleted();
                contexto.Database.EnsureCreated();
                //Arrange
                contexto.Funcionarios.Add(new Funcionario("Cleide", "111.111.111-11"));
                contexto.Funcionarios.Add(new Funcionario("Ravona", "222.222.222-22"));
                contexto.SaveChanges();

                var listaFuncionariosExistentes = new List<Funcionario> { new Funcionario("Cleide", "111.111.111-11"), new Funcionario("Ravona", "222.222.222-22") };

                var repo = new Repositorio_Funcionario(contexto);

                //Action
                void Acao() => repo.AddFuncionarios(listaFuncionariosExistentes);

                //Assert
                var mensagem = Assert.Throws<DuplicateNameException>(Acao).Message;
                Assert.Equal(mensagemEsperada, mensagem);
            }
        }
    }
}
