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
        //public Empresa Empresa {get; set;} --> Falta PR Adicionando Empresa
        public Servico Servico { get; set; }
        public Horario Horario { get; set; }

        private Agendamento() { }

        public Agendamento(Funcionario funcionario, Servico servico, Horario horario)
        {
            ValidarDadosDeCriacao(funcionario, servico, horario);
            Funcionario = funcionario;
            Servico = servico;
            Horario = horario;
        }

        private void ValidarDadosDeCriacao(Funcionario funcionario, Servico servico, Horario horario)
        {
            if (funcionario == null) throw new Exception("O funcionário não pode ser nulo");
            if (servico == null) throw new Exception("O serviço não pode ser nulo");
            if (horario == null) throw new Exception("O horário não pode ser nulo");
        }
    }
}
