using System;
using System.Globalization;

namespace ProjetoIntegradorMVC.Models
{
    public class Data
    {
        public int Id { get; private set; }
        public DateTime Dia { get; private set; }
        private Data() { }
        public Data(string dia)
        {
            Dia = ObterComoData(dia);
        }

        private static DateTime ObterComoData(string dia)
        {
            var converteuCorretamente = DateTime.TryParseExact(dia, "dd/MM/yyyy",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out var diaConvertido);
            if (!converteuCorretamente) throw new Exception("Data Invalida");

            return diaConvertido;
        }
    }
}