using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Operacoes
{
    public class Agendamento
    {
        public int Id { get; set; }
        public Funcionario Funcionario { get; set; }
        public Empresa Empresa {get; set;}
        public Servico Servico { get; set; }
        public DataEHora Horario { get; set; }
        public Cliente Cliente { get; set; }

        private Agendamento() { }

        public Agendamento(Funcionario funcionario, Empresa empresa, Servico servico, DataEHora horario, Cliente cliente)
        {
            ValidarDadosDeCriacao(funcionario, empresa, servico, horario, cliente);
            Funcionario = funcionario;
            Empresa = empresa;
            Servico = servico;
            Horario = horario;
            Cliente = cliente;
        }

        private void ValidarDadosDeCriacao(Funcionario funcionario, Empresa empresa, Servico servico, DataEHora horario, Cliente cliente)
        {
            if (funcionario == null) throw new Exception("O funcionário não pode ser nulo");
            if (empresa == null) throw new Exception("A empresa nao pode ser nula");
            if (servico == null) throw new Exception("O serviço não pode ser nulo");
            if (horario == null) throw new Exception("O horário não pode ser nulo");
            if (cliente == null) throw new Exception("O cliente não pode ser nulo");
        }
    }
}
