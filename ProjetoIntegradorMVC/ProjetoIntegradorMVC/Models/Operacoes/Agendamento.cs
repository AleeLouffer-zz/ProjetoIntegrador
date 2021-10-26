using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Operacoes
{
    public class Agendamento
    {
        public int Id { get; private set; }
        public Funcionario Funcionario { get; private set; }
        public Empresa Empresa {get; private set; }
        public Servico Servico { get; private set; }
        public DateTime Horario { get; private set; }
        public Cliente Cliente { get; private set; }

        private Agendamento() { }

        public Agendamento(Funcionario funcionario, Empresa empresa, Servico servico, string horario, Cliente cliente)
        {
            ValidarDadosDeCriacao(funcionario, empresa, servico, horario, cliente);
            Funcionario = funcionario;
            Empresa = empresa;
            Servico = servico;
            Horario = ObterComoHoraEData(horario);
            Cliente = cliente;
        }

        private void ValidarDadosDeCriacao(Funcionario funcionario, Empresa empresa, Servico servico, string horario, Cliente cliente)
        {
            if (funcionario == null) throw new Exception("O campo funcionário deve ser preenchido");
            if (empresa == null) throw new Exception("O campo empresa deve ser preenchido");
            if (servico == null) throw new Exception("O campo serviço deve ser preenchido");
            if (string.IsNullOrWhiteSpace(horario)) throw new Exception("O campo horário deve ser preenchido");
            if (cliente == null) throw new Exception("O campo cliente deve ser preenchido");
        }
        private static DateTime ObterComoHoraEData(string dataEHora)
        {
            var converteuCorretamente = DateTime.TryParseExact(dataEHora, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dataEHoraConvertido);
            if (!converteuCorretamente) throw new Exception("Data e hora inválidos");    
            return dataEHoraConvertido;
        }
    }
}
