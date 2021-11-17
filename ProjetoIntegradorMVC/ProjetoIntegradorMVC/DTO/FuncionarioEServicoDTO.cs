using System.Collections.Generic;

namespace ProjetoIntegradorMVC.DTO
{
    public class FuncionarioEServicoDTO
    {
        public List<FuncionarioDTO> Funcionarios { get; set; } = new List<FuncionarioDTO>();
        public ServicoDTO Servico { get; set; }

        public FuncionarioEServicoDTO(List<FuncionarioDTO> funcionarios, ServicoDTO servico)
        {
            Funcionarios = funcionarios;
            Servico = servico;
        }
    }
}
