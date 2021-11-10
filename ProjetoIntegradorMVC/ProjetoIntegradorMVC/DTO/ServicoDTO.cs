using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.DTO
{
    public class ServicoDTO
    {
        private ServicoDTO() { }
        public ServicoDTO(Servico servico, List<Funcionario> funcionario)
        {
            Servico = servico;
            Funcionarios = funcionario;
        }

        public Servico Servico { get; set; }
        public List<Funcionario> Funcionarios { get; set; }

    }
}
