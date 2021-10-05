using Microsoft.EntityFrameworkCore;
using PI.Testes.Helpers;
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
        private readonly RepositorioFuncionario _repositorio;
        private readonly BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        public RepositorioFuncionarioTeste()
        {
            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteFuncionarios");
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);

            _repositorio = new RepositorioFuncionario(_contexto);
        }

        [Fact]
        public void Deve_retornar_funcionarios_pelas_ids()
        {
            _contexto.Funcionarios.Add(new Funcionario("Cleide","cleide@cleide.com", "123", "111.111.111-11"));
            _contexto.Funcionarios.Add(new Funcionario("Ravona", "ravona@ravona.com", "ravona@ravona.com", "222.222.222-22"));
            _contexto.SaveChanges();
            var ids = new List<int>() { 1, 2 };

            var funcionarios = _repositorio.BuscarFuncionariosPorIds(ids);

            var funcionariosIds = funcionarios.Select(funcionario => funcionario.Id).ToList();
            Assert.Equal(ids, funcionariosIds);
        }

        [Fact]
        public void Deve_adicionar_os_funcionarios()
        {
            var funcionariosASeremAdicionados = new List<Funcionario> { new Funcionario("Cleido","cleido@cleido.com", "123",  "131.111.111-11"), 
                new Funcionario("Ravon","ravon@ravon.com", "123", "422.222.222-22") };
            _repositorio.AdicionarFuncionarios(funcionariosASeremAdicionados);
            var funcionariosRetornados = new List<Funcionario>();

            foreach (var funcionario in funcionariosASeremAdicionados)
            {
                funcionariosRetornados.Add(_repositorio.BuscarFuncionarioPorCpf(funcionario.CPF));
            }

            Assert.Equal(funcionariosASeremAdicionados, funcionariosRetornados);
        }

        [Fact]
        public void Deve_verificar_funcionario_existente()
        {
            _contexto.Funcionarios.Add(new Funcionario("Cleide", "cleide@cleide.com", "123", "111.111.111-11"));
            _contexto.Funcionarios.Add(new Funcionario("Ravona", "ravona@ravona.com", "ravona@ravona.com", "222.222.222-22"));
            _contexto.SaveChanges();
            var listaFuncionariosExistentes = new List<Funcionario> { new Funcionario("Cleide", "cleide@cleide.com", "123", "111.111.111-11"), 
                new Funcionario("Ravona", "ravona@ravona.com", "ravona@ravona.com", "222.222.222-22") };

            var funcionarioExiste = _repositorio.VerificarFuncionarioExistente(listaFuncionariosExistentes[0]);

            Assert.True(funcionarioExiste);
        }

        [Fact]
        public void Nao_deve_adicionar_funcionario_existente()
        {
            const string mensagemEsperada = "O funcionário já existe";
            _contexto.Funcionarios.Add(new Funcionario("Cleide", "cleide@cleide.com", "123", "111.111.111-11"));
            _contexto.Funcionarios.Add(new Funcionario("Ravona", "ravona@ravona.com", "ravona@ravona.com", "222.222.222-22"));
            _contexto.SaveChanges();
            var listaFuncionariosExistentes = new List<Funcionario> { new Funcionario("Cleide", "cleide@cleide.com", "123", "111.111.111-11"), 
                new Funcionario("Ravona", "ravona@ravona.com", "ravona@ravona.com", "222.222.222-22") };

            void Acao() => _repositorio.AdicionarFuncionarios(listaFuncionariosExistentes);

            var mensagem = Assert.Throws<DuplicateNameException>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
