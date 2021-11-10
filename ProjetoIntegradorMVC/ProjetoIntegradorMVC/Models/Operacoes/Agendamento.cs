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
        public DateTime HoraEData { get; private set; }
        public Cliente Cliente { get; private set; }

        private Agendamento() { }

        public Agendamento(Funcionario funcionario, Empresa empresa, Servico servico, DateTime horario, Cliente cliente)
        {
            ValidarDadosDeCriacao(funcionario, empresa, servico, horario, cliente);
            Funcionario = funcionario;
            Empresa = empresa;
            Servico = servico;
            HoraEData = horario;
            Cliente = cliente;
        }

        private void ValidarDadosDeCriacao(Funcionario funcionario, Empresa empresa, Servico servico, DateTime horario, Cliente cliente)
        {
            if (funcionario == null) throw new Exception("O campo funcionário deve ser preenchido");
            if (empresa == null) throw new Exception("O campo empresa deve ser preenchido");
            if (servico == null) throw new Exception("O campo serviço deve ser preenchido");
            if (cliente == null) throw new Exception("O campo cliente deve ser preenchido");
            if (horario <= DateTime.Now) throw new Exception("O agendamento deve ser feito em uma data e horario valida");
        }
    }
}
