using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProjetoIntegradorMVC.Models
{
    public class HorarioDeTrabalho
    {
        public int Id { get; private set; }
        public DateTime Horario { get; private set; }

        private HorarioDeTrabalho () { }

        public HorarioDeTrabalho(string horario)
        {
            Horario = ObterComoHoraEMinuto(horario);
        }

        private DateTime ObterComoHoraEMinuto(string horario)
        {
            var converteuCorretamente = DateTime.TryParseExact(horario, "HH:mm",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out var horaEMinutoConvertido);
            if (!converteuCorretamente) throw new Exception("Horario inválido");

            return horaEMinutoConvertido;
        }
    }
}