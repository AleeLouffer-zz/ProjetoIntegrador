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
        private readonly string _horaEData;
        private readonly Empresa _empresa;
        private readonly Cliente _cliente;

        public AgendamentoTeste()
        {
            _empresa = new Empresa("Inteligencia LTDA", "Inteligencia", "inteligencia@inteligencia.com.br", "12345", "05389493000117", "79004394");
            _funcionario = new Funcionario("Daniel", "daniel-zanelato@gmail.com", "123", "59819300045", _empresa);
            _servico = new Servico("Corte de cabelo", "descricao", 123m, _empresa, Local.Ambos);
            _horaEData = "12/12/2001 13:00:00";
            
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
                HoraEData = DateTime.ParseExact(_horaEData, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Cliente = _cliente
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
        public void Nao_deve_criar_agendamento_com_horario_nulo()
        {
            var mensagemEsperada = "O campo horário deve ser preenchido";

            void Acao() => new Agendamento(_funcionario, _empresa, _servico, null, _cliente);

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
    }
}