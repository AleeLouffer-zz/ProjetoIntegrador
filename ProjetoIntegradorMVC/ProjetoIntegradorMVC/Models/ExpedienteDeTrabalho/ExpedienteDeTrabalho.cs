using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.Usuarios;

namespace ProjetoIntegradorMVC.Models
{
    public class ExpedienteDeTrabalho
    {
        public int Id { get; private set;  }
        public Funcionario Funcionario { get; private set; }
        public int FuncionarioId { get; private set; }
        public DayOfWeek DiaDaSemana { get; private set; }
        public DateTime HoraDeInicio { get; private set; }
        public DateTime HoraDaSaida { get; private set; }
        public DateTime EntradaDoIntervalo { get; private set; }
        public DateTime SaidaDoIntervalo { get; private set; }

        private ExpedienteDeTrabalho() { }

        public ExpedienteDeTrabalho(Funcionario funcionario, DayOfWeek diaDaSemana, string horaDeInicio, string horaDaSaida)
        {
            Funcionario = funcionario;
            FuncionarioId = funcionario.Id;
            DiaDaSemana = diaDaSemana;
            HoraDeInicio = ObterComoHoraEMinuto(horaDeInicio);
            HoraDaSaida = ObterComoHoraEMinuto(horaDaSaida);
        }

        public ExpedienteDeTrabalho(Funcionario funcionario, DayOfWeek diaDaSemana, string horaDeInicio, string horaDaSaida, string entradaIntervalo, string saidaIntervalo)
        {
            Funcionario = funcionario;
            FuncionarioId = funcionario.Id;
            DiaDaSemana = diaDaSemana;
            HoraDeInicio = ObterComoHoraEMinuto(horaDeInicio);
            HoraDaSaida = ObterComoHoraEMinuto(horaDaSaida);
            EntradaDoIntervalo = ObterComoHoraEMinuto(entradaIntervalo);
            SaidaDoIntervalo = ObterComoHoraEMinuto(saidaIntervalo);
        }

        private static DateTime ObterComoHoraEMinuto(string horario)
        {
            var converteuCorretamente = DateTime.TryParseExact(horario, "HH:mm",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out var horaEMinutoConvertido);
            if (!converteuCorretamente) throw new Exception("Horario inválido");

            return horaEMinutoConvertido;//
        }
    }
}