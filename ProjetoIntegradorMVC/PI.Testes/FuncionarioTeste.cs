using System;
using Xunit;
using ExpectedObjects;
using ProjetoIntegradorMVC.Models.Usuarios;
using PI.Testes.Helpers;
using ProjetoIntegradorMVC.Repositorio;
using ProjetoIntegradorMVC.Models.ContextoDb;

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

        public FuncionarioTeste()
        {
            _nome = "Daniel";
            _email = "daniel-zanelato@hotmail.com";
            _senha = "alecrimdourado";
            _cpf = "43144383960";

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
                CPF = _cpf
            }.ToExpectedObject();

            var funcionario = new Funcionario(_nome, _email, _senha, _cpf);

            funcionarioEsperado.ShouldMatch(funcionario);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_funcionario_sem_nome(string nomeInvalido)
        {
            const string mensagemEsperada = "O funcionário deve ter um nome";

            void Acao() => new Funcionario(nomeInvalido, _email,  _senha, _cpf);

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

            void Acao() => new Funcionario(_nome, emailInvalido, _senha, _cpf);

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

            void Acao() => new Funcionario(_nome, _email, senhaInvalida, _cpf);

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

            void Acao() => new Funcionario(_nome, _email, _senha, cpfInvalido);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Deve_verificar_que_funcionario_existe_no_banco()
        {
            var funcionario = new Funcionario(_nome, _email, _senha, _cpf);
            _repositorio.AdicionarUm(funcionario);

            var existeNoBanco = funcionario.ExisteNoBanco(_repositorio);

            Assert.True(existeNoBanco);
        }

        [Fact]
        public void Deve_verificar_que_funcionario_nao_existe_no_banco()
        {
            var funcionario = new Funcionario(_nome, _email, _senha, "00207862125");

            var existeNoBanco = funcionario.ExisteNoBanco(_repositorio);

            Assert.False(existeNoBanco);
        }
    }
}
