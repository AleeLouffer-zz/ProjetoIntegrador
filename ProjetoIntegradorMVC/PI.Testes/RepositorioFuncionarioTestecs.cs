using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
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
    public class RepositorioFuncionarioTeste
    {
        private readonly Contexto _contexto;
        private readonly Repositorio_Funcionario _repo;
        private Funcionario _funcionario;
        private Funcionario _funcionario2;
        private JornadaDeTrabalho _jornada;

        public RepositorioFuncionarioTeste()
        {
            var options = new DbContextOptionsBuilder<Contexto>()
                .UseInMemoryDatabase(databaseName: "DBTesteFuncionarios")
                .Options;

            _contexto = new Contexto(options);
            _contexto.Database.EnsureDeleted();
            _contexto.Database.EnsureCreated();

            _repo = new Repositorio_Funcionario(_contexto);
            
            var diasDeTrabalho = new List<DiaDeTrabalho> { new DiaDeTrabalho("Segunda"), new DiaDeTrabalho("Terca"), new DiaDeTrabalho("Quarta"), new DiaDeTrabalho("Quinta"), new DiaDeTrabalho("Sexta")};
            var horariosDeTrabalho = new List<HorarioDeTrabalho> { new HorarioDeTrabalho("08:00"), new HorarioDeTrabalho("12:00"), new HorarioDeTrabalho("13:00"), new HorarioDeTrabalho("17:00") };
            _jornada = new(diasDeTrabalho, horariosDeTrabalho);

            _funcionario = new("Cleide", "cleide@cleide.com", "123", "111.111.111-11", _jornada);
            _funcionario2 = new("Ravona", "ravona@ravona.com", "ravona@ravona.com", "222.222.222-22", _jornada);
        }
        [Fact]
        public void Deve_retornar_funcionarios_pelas_ids()
        {
            _contexto.Funcionarios.Add(_funcionario);
            _contexto.Funcionarios.Add(_funcionario2);
            _contexto.SaveChanges();

            var ids = new List<int>() { 1, 2 };

            var funcionarios = _repo.GetFuncionarios(ids);

            Assert.Equal(ids[1], funcionarios[1].Id);
        }

        [Fact]
        public void Deve_adicionar_os_funcionarios()
        {
            var listaFuncionarios = new List<Funcionario> { new Funcionario("Cleido","cleido@cleido.com", "123",  "131.111.111-11", _jornada), 
                new Funcionario("Ravon","ravon@ravon.com", "123", "422.222.222-22", _jornada) };

            _repo.AddFuncionarios(listaFuncionarios);

            Assert.Equal(2, _contexto.Funcionarios.Count());
        }

        [Fact]
        public void Deve_verificar_funcionario_existente()
        {
            _contexto.Funcionarios.Add(_funcionario);
            _contexto.Funcionarios.Add(_funcionario2);
            _contexto.SaveChanges();

            var listaFuncionariosExistentes = new List<Funcionario> { _funcionario, _funcionario2 };

            var funcionariosExistentes = _repo.VerificarFuncionarioExistente(listaFuncionariosExistentes[0]);

            Assert.True(funcionariosExistentes);
        }

        [Fact]
        public void Nao_deve_adicionar_funcionario_existente()
        {
            const string mensagemEsperada = "O funcionário já existe";

            _contexto.Funcionarios.Add(_funcionario);
            _contexto.Funcionarios.Add(_funcionario2);
            _contexto.SaveChanges();

            var listaFuncionariosExistentes = new List<Funcionario> { _funcionario, _funcionario2 };

            void Acao() => _repo.AddFuncionarios(listaFuncionariosExistentes);

            var mensagem = Assert.Throws<DuplicateNameException>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
