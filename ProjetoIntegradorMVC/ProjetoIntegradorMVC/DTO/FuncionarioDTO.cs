using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.DTO
{
    public class FuncionarioDTO
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
        public List<Agendamento> Agendamentos { get; set; } = new();
        public List<ExpedienteDeTrabalho> ExpedientesDeTrabalho { get; set; } = new();
        
        public FuncionarioDTO(Funcionario funcionario)
        {
            Nome = funcionario.Nome;
            CPF = funcionario.CPF; 
            Empresa = funcionario.Empresa;  
            EmpresaId = funcionario.EmpresaId;
            Agendamentos = funcionario.Agendamentos;
            ExpedientesDeTrabalho = funcionario.ExpedientesDeTrabalho;              
        }
    }
}
