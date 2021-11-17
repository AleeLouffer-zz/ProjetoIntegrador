using ExpectedObjects;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace PI.Testes
{
    public class AgendamentoTeste
    {
        private readonly Funcionario _funcionario;
        private readonly Servico _servico;
        private readonly DateTime _horaEData;
        private readonly Empresa _empresa;
        private readonly Cliente _cliente;

        public AgendamentoTeste()
        {
            _empresa = new Empresa("Inteligencia LTDA", "Inteligencia", "inteligencia@inteligencia.com.br", "12345", "05389493000117", "79004394");
            _funcionario = new Funcionario("Daniel", "daniel-zanelato@gmail.com", "123", "59819300045", _empresa);
            _servico = new Servico("Corte de cabelo", "descricao", 123m, _empresa, Local.Ambos);
            _horaEData = new DateTime(2021, 11, 9, 14, 00, 01);
            
            _cliente = new Cliente("Jessica", "jessica@hotmail.com", "jessicalindona", "06064104147");
        }
        [Fact]
        public void Deve_criar_um_agendamento()
        {
            var agendamentoEsperado = new
            {
                Funcionario = _funcionario,
                Empresa = _empresa,
                Servico = _servico,
                HoraEData = _horaEData
            }.ToExpectedObject();

            var agendamento = new Agendamento(_funcionario, _empresa, _servico, _horaEData, _cliente);

            agendamentoEsperado.ShouldMatch(agendamento);
        }

        [Fact]
        public void Nao_deve_criar_agendamento_com_funcionario_nulo()
        {
            var mensagemEsperada = "O campo funcionário deve ser preenchido";

            void Acao() => new Agendamento(null, _empresa,_servico, _horaEData, _cliente);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Nao_deve_criar_agendamento_com_empresa_nulo()
        {
            var mensagemEsperada = "O campo empresa deve ser preenchido";

            void Acao() => new Agendamento(_funcionario, null, _servico, _horaEData, _cliente);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Nao_deve_criar_agendamento_com_servico_nulo()
        {
            var mensagemEsperada = "O campo serviço deve ser preenchido";

            void Acao() => new Agendamento(_funcionario, _empresa, null, _horaEData, _cliente);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Nao_deve_criar_agendamento_com_cliente_nulo()
        {
            var mensagemEsperada = "O campo cliente deve ser preenchido";

            void Acao() => new Agendamento(_funcionario, _empresa, _servico, _horaEData, null);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Nao_deve_criar_um_agendamento_com_data_e_horario_invalido()
        {
            var horaEData = new DateTime(2021, 11, 10, 14, 00, 01);
            var mensagemEsperada = "O agendamento deve ser feito em uma data e horario valida";

            void Acao() => new Agendamento(_funcionario, _empresa, _servico, horaEData, _cliente);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}