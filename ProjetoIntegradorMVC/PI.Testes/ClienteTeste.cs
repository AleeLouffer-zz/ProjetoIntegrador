using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ExpectedObjects;
using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Models;

namespace PI.Testes
{
    public class ClienteTeste
    {
        private string _nome;
        private string _email;
        private string _senha;
        private string _cpf;
        public ClienteTeste()
        {
            _nome = "Jessica";
            _email = "jessica@hotmail.com";
            _senha = "jessicalindona";
            _cpf = "06064104147";
        }

        [Fact]
        public void Deve_criar_um_cliente()
        {
            var clienteEsperado = new
            {
                Nome = _nome,
                Email = _email,
                Senha = _senha,
                CPF = _cpf,
            }.ToExpectedObject();

            var cliente = new Cliente(_nome, _email, _senha, _cpf);

            clienteEsperado.ShouldMatch(cliente);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_cliente_sem_nome(string nomeInvalido)
        {
            const string mensagemEsperada = "O campo nome deve ser preenchido";

            void Acao() => new Cliente(nomeInvalido, _email, _senha, _cpf);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_cliente_sem_email(string emailInvalido)
        {
            const string mensagemEsperada = "O campo e-mail deve ser preenchido";

            void Acao() => new Cliente(_nome, emailInvalido, _senha, _cpf);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_cliente_sem_senha(string senhaInvalida)
        {
            const string mensagemEsperada = "É necessário possuir uma senha";

            void Acao() => new Cliente(_nome, _email, senhaInvalida, _cpf);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_cliente_sem_cpf(string cpfInvalido)
        {
            const string mensagemEsperada = "O campo CPF deve ser preenchido";

            void Acao() => new Cliente(_nome, _email, _senha, cpfInvalido);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData("000000000000")]
        [InlineData("1")]
        public void Nao_deve_criar_um_cliente_com_cpf_invalido(string cpfInvalido)
        {
            const string mensagemEsperada = "CPF inválido";

            void Acao() => new Cliente(_nome, _email, _senha, cpfInvalido);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
