using System;
using Xunit;
using ExpectedObjects;
using ProjetoIntegradorMVC.Models.Usuarios;
using PI.Testes.Helpers;
using ProjetoIntegradorMVC.Repositorio;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models;
using System.Collections.Generic;

namespace PI.Testes
{
    public class FuncionarioTeste
    {
        private string _nome;
        private string _email;
        private string _senha;
        private string _cpf;

        private BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        private RepositorioFuncionario _repositorio;
        private Contexto _contexto;

        private JornadaDeTrabalho _jornada;
        public FuncionarioTeste()
        {
            _nome = "Daniel";
            _email = "daniel-zanelato@hotmail.com";
            _senha = "alecrimdourado";
            _cpf = "59819300045";
            var diasDeTrabalho = new List<DiaDaSemana> { new DiaDaSemana("Segunda"), new DiaDaSemana("Terca"), new DiaDaSemana("Quarta"), new DiaDaSemana("Quinta"), new DiaDaSemana("Sexta") };
            var horariosDeTrabalho = new List<Horario> { new Horario("08:00"), new Horario("12:00"), new Horario("13:00"), new Horario("17:00") };
            _jornada = new (diasDeTrabalho, horariosDeTrabalho);

            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteFuncionario");
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);

            _repositorio = new RepositorioFuncionario(_contexto);
        }

        [Fact]
        public void Deve_criar_um_funcionario()
        {
            var funcionarioEsperado = new
            {
                Nome = _nome,
                Email = _email,
                Senha = _senha,
                CPF = _cpf,
                JornadaDeTrabalho = _jornada
            }.ToExpectedObject();

            var funcionario = new Funcionario(_nome, _email, _senha, _cpf, _jornada);

            funcionarioEsperado.ShouldMatch(funcionario);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_funcionario_sem_nome(string nomeInvalido)
        {
            const string mensagemEsperada = "O funcionário deve ter um nome";

            void Acao() => new Funcionario(nomeInvalido, _email,  _senha, _cpf, _jornada);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_funcionario_sem_email(string emailInvalido)
        {
            const string mensagemEsperada = "O funcionário deve ter um email";

            void Acao() => new Funcionario(_nome, emailInvalido, _senha, _cpf, _jornada);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_funcionario_sem_senha(string senhaInvalida)
        {
            const string mensagemEsperada = "O funcionário deve ter uma senha";

            void Acao() => new Funcionario(_nome, _email, senhaInvalida, _cpf, _jornada);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_funcionario_sem_cpf(string cpfInvalido)
        {
            const string mensagemEsperada = "O funcionário deve ter um cpf";

            void Acao() => new Funcionario(_nome, _email, _senha, cpfInvalido, _jornada);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData("000000000000")]
        [InlineData("1")]
        public void Nao_deve_criar_um_funcionario_com_cpf_invalido(string cpfInvalido)
        {
            const string mensagemEsperada = "O funcionario deve ter um CPF valido";

            void Acao() => new Funcionario(_nome, _email, _senha, cpfInvalido, _jornada);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Deve_verificar_que_funcionario_existe_no_banco()
        {
            var funcionario = new Funcionario(_nome, _email, _senha, _cpf, _jornada);
            _repositorio.Adicionar(funcionario);

            var existeNoBanco = funcionario.ValidarFuncionarioExistente(_repositorio);

            Assert.True(existeNoBanco);
        }

        [Fact]
        public void Deve_verificar_que_funcionario_nao_existe_no_banco()
        {
            var funcionario = new Funcionario(_nome, _email, _senha, "00207862125", _jornada);

            var existeNoBanco = funcionario.ValidarFuncionarioExistente(_repositorio);

            Assert.False(existeNoBanco);
        }
    }
}
