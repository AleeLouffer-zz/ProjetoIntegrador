using System.Collections.Generic;

namespace ProjetoIntegradorMVC.DTO
{
    public class FuncionarioEServicoDTO
    {
        public List<FuncionarioDTO> Funcionarios { get; set; } = new List<FuncionarioDTO>();
        public List<ServicoDTO> Servicos { get; set; } = new List<ServicoDTO>();

        public FuncionarioEServicoDTO(List<FuncionarioDTO> funcionarios, List <ServicoDTO> servicos)
        {
            Funcionarios = funcionarios;
            Servicos = servicos;
        }
    }
}
