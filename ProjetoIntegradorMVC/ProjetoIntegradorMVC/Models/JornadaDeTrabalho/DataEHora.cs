using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models
{
    public class DataEHora
    {
        public int Id { get; private set; }
        public DateTime HoraEData { get; set; }

        public DataEHora() { }
        public DataEHora(string dataEHora)
        {
            HoraEData = ObterComoHoraEData(dataEHora);
        }
        private static DateTime ObterComoHoraEData(string dataEHora)
        {
            var converteuCorretamente = DateTime.TryParseExact(dataEHora, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dataEHoraConvertido);
            if (!converteuCorretamente) throw new Exception("Data e hora inválidos");

            return dataEHoraConvertido;
        }

    }
}
