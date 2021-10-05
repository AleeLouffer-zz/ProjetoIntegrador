using ExpectedObjects;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using Xunit;

namespace PI.Testes
{
    public class AgendamentoTeste
    {
        private readonly Funcionario _funcionario;
        private readonly Servico _servico;
        private readonly JornadaDeTrabalho _jornadaDoFuncionario;
        private readonly Horario _horario;

        public AgendamentoTeste()
        {
            var diasDeTrabalho = new List<DiaDaSemana> { new DiaDaSemana("Segunda"), new DiaDaSemana("Terca"), new DiaDaSemana("Quarta"), new DiaDaSemana("Quinta"), new DiaDaSemana("Sexta") };
            var horariosDeTrabalho = new List<Horario> { new Horario("08:00"), new Horario("12:00"), new Horario("13:00"), new Horario("17:00") };
            _jornadaDoFuncionario = new(diasDeTrabalho, horariosDeTrabalho);
            _funcionario = new Funcionario("Daniel", "daniel-zanelato@gmail.com", "123", "59819300045", _jornadaDoFuncionario);
            _servico = new Servico("Corte de cabelo", "descricao", 123m);
            _horario = new Horario("13:00");
        }

        [Fact]
        public void Nao_deve_criar_agendamento_com_funcionario_nulo()
        {
            var mensagemEsperada = "O funcionário não pode ser nulo";

            void Acao() => new Agendamento(null, _servico, _horario);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Nao_deve_criar_agendamento_com_servico_nulo()
        {
            var mensagemEsperada = "O serviço não pode ser nulo";

            void Acao() => new Agendamento(_funcionario, null, _horario);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Nao_deve_criar_agendamento_com_horario_nulo()
        {
            var mensagemEsperada = "O horário não pode ser nulo";

            void Acao() => new Agendamento(_funcionario, _servico, null);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}