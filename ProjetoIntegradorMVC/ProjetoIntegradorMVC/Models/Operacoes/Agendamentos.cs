using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Operacoes
{
    [Table("Agendamentos")]
    public class Agendamentos
    {
        public int Id { get; private set; }
        public DateTime Data { get; private set; }
        public Cliente Cliente { get; private set; }
        public Servico Servico { get; private set; }

        public Agendamentos(DateTime data, Cliente cliente, Servico servico)
        {
            Data = data;
            Cliente = cliente;
            Servico = servico;
        }
    }
}
