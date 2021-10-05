using ExpectedObjects;
using ProjetoIntegradorMVC.Models;
using System;
using System.Globalization;
using Xunit;

namespace PI.Testes
{
    public class HorarioTeste
    {
        [Fact]
        public void Deve_criar_um_horario_de_trabalho()
        {
            var horario = DateTime.ParseExact("13:00", "HH:mm", CultureInfo.InvariantCulture);

            var horarioDeTrabalho = new Horario("13:00");

            Assert.Equal(horario, horarioDeTrabalho.Hora);
        }
    }
}