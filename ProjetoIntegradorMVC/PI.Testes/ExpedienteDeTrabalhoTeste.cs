using ExpectedObjects;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace PI.Testes
{
    public class ExpedienteDetrabalhoTeste
    {
        private Funcionario _funcionario;
        private Empresa _empresa;
        private readonly DayOfWeek _diaDaSemana;
        private readonly string _horaInicial;
        private readonly string _horaFinal;


        public ExpedienteDetrabalhoTeste()
        {
            _empresa = new Empresa("Fulano LTDA", "Fulano", "fulano@fulano", "12345", "05389493000117", "79080290");
            _funcionario = new Funcionario("Fulano", "fulano@fulano", "12345", "06297337160", _empresa);

            _diaDaSemana = DayOfWeek.Friday;
            _horaInicial = "08:00";
            _horaFinal = "18:00";
        }

        [Fact]
        public void Deve_criar_um_expediente_de_trabalho()
        {
            var expedienteEsperado = new
            {
                Funcionario = _funcionario,
                DiaDaSemana = _diaDaSemana,
                HoraDeInicio = DateTime.ParseExact(_horaInicial, "HH:mm", CultureInfo.InvariantCulture),
                HoraDaSaida = DateTime.ParseExact(_horaFinal, "HH:mm", CultureInfo.InvariantCulture),
            }.ToExpectedObject();

            var expediente = new ExpedienteDeTrabalho(_funcionario, _diaDaSemana, _horaInicial, _horaFinal);

            expedienteEsperado.ShouldMatch(expediente);
        }

        [Fact]
        public void Deve_criar_um_expediente_de_trabalho_com_intervalo()
        {
            var expedienteEsperado = new
            {
                Funcionario = _funcionario,
                DiaDaSemana = _diaDaSemana,
                HoraDeInicio = DateTime.ParseExact(_horaInicial, "HH:mm", CultureInfo.InvariantCulture),
                HoraDaSaida = DateTime.ParseExact(_horaFinal, "HH:mm", CultureInfo.InvariantCulture),
                EntradaDoIntervalo = DateTime.ParseExact("12:00", "HH:mm", CultureInfo.InvariantCulture),
                SaidaDoIntervalo = DateTime.ParseExact("13:00", "HH:mm", CultureInfo.InvariantCulture),
            }.ToExpectedObject();

            var expediente = new ExpedienteDeTrabalho(_funcionario, _diaDaSemana, _horaInicial, _horaFinal, "12:00", "13:00");

            expedienteEsperado.ShouldMatch(expediente);
        }

        [Fact]
        public void Deve_retornar_um_horario()
        {
            var horaInicial = DateTime.ParseExact("13:00", "HH:mm", CultureInfo.InvariantCulture);

            var expediente = new ExpedienteDeTrabalho(_funcionario, _diaDaSemana, "13:00", _horaFinal);

            Assert.Equal(horaInicial, expediente.HoraDeInicio);
        }
    }
}

