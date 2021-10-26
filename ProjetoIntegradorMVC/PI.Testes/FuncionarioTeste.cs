using System;
using Xunit;
using ExpectedObjects;
using ProjetoIntegradorMVC.Models.Usuarios;
using PI.Testes.Helpers;
using ProjetoIntegradorMVC.Repositorio;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace PI.Testes
{
    public class FuncionarioTeste
    {
        private string _nome;
        private string _email;
        private string _senha;
        private string _cpf;
        private Empresa _empresa;

        public FuncionarioTeste()
        {
            _empresa = new Empresa("Inteligencia LTDA", "Inteligencia", "inteligencia@inteligencia.com.br", "12345", "05389493000117", "79004394");
            _nome = "Daniel";
            _email = "daniel-zanelato@hotmail.com";
            _senha = "alecrimdourado";
            _cpf = "59819300045";
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
            }.ToExpectedObject();

            var funcionario = new Funcionario(_nome, _email, _senha, _cpf, _empresa);

            funcionarioEsperado.ShouldMatch(funcionario);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_funcionario_sem_nome(string nomeInvalido)
        {
            const string mensagemEsperada = "O funcionário deve ter um nome";

            void Acao() => new Funcionario(nomeInvalido, _email, _senha, _cpf, _empresa);

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

            void Acao() => new Funcionario(_nome, emailInvalido, _senha, _cpf, _empresa);

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

            void Acao() => new Funcionario(_nome, _email, senhaInvalida, _cpf, _empresa);

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

            void Acao() => new Funcionario(_nome, _email, _senha, cpfInvalido, _empresa);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData("000000000000")]
        [InlineData("1")]
        public void Nao_deve_criar_um_funcionario_com_cpf_invalido(string cpfInvalido)
        {
            const string mensagemEsperada = "O funcionario deve ter um CPF valido";

            void Acao() => new Funcionario(_nome, _email, _senha, cpfInvalido, _empresa);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Deve_adicionar_expediente_no_funcionario()
        {
            var funcionario = new Funcionario(_nome, _email, _senha, _cpf, _empresa);

            var expedienteEsperado = new ExpedienteDeTrabalho(funcionario, DayOfWeek.Friday, "08:00", "18:00");

            funcionario.AdicionarExpediente(DayOfWeek.Friday, "08:00", "18:00");

            Assert.Equal(funcionario.ExpedientesDeTrabalho.FirstOrDefault().HoraDaSaida , expedienteEsperado.HoraDaSaida);
        }
    }
}