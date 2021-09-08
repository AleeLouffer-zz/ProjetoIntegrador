using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ExpectedObjects;
using ProjetoIntegradorMVC.Models.Usuarios;

namespace PI.Testes
{
    public class FuncionarioTeste
    {

        private string _nome;
        private string _email;
        private string _senha;
        private string _cpf;
        public FuncionarioTeste()
        {
            _nome = "Daniel";
            _email = "daniel-zanelato@hotmail.com";
            _senha = "alecrimdourado";
            _cpf = "43144383960";
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
    }
}
