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
    public class FuncionarioTeste
    {
        private string _nome;
        private string _email;
        private string _senha;
        private string _cpf;
        private JornadaDeTrabalho _jornada;
        public FuncionarioTeste()
        {
            _nome = "Daniel";
            _email = "daniel-zanelato@hotmail.com";
            _senha = "alecrimdourado";
            _cpf = "59819300045";
            var diasDeTrabalho = new List<DiaDeTrabalho> { new DiaDeTrabalho("Segunda"), new DiaDeTrabalho("Terca"), new DiaDeTrabalho("Quarta"), new DiaDeTrabalho("Quinta"), new DiaDeTrabalho("Sexta") };
            var horariosDeTrabalho = new List<HorarioDeTrabalho> { new HorarioDeTrabalho("08:00"), new HorarioDeTrabalho("12:00"), new HorarioDeTrabalho("13:00"), new HorarioDeTrabalho("17:00") };
            _jornada = new (diasDeTrabalho, horariosDeTrabalho);
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
    }
}
