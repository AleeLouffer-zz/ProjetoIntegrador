using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProjetoIntegradorMVC.Models
{
    public class Horario
    {
        public int Id { get; private set; }
        public DateTime Hora { get; private set; }
        private Horario() { }
        public Horario(string hora)
        {
            Hora = ObterComoHoraEMinuto(hora);
        }
        private static DateTime ObterComoHoraEMinuto(string hora)
        {
            var converteuCorretamente = DateTime.TryParseExact(hora, "HH:mm",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out var horaEMinutoConvertido);
            if (!converteuCorretamente) throw new Exception("Horario inválido");

            return horaEMinutoConvertido;
        }
    }
}