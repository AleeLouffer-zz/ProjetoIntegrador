using ProjetoIntegradorMVC.DTO;
using ProjetoIntegradorMVC.Repositorio;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Aplicacoes
{
    public class DetalhesDoServico : IDetalhesDoServico
    {
        private readonly IRepositorioServico _repositorioServico;
        private readonly IRepositorioFuncionariosComServicos _repositorioFuncionarioComServico;
        private readonly IRepositorioFuncionario _repositorioFuncionario;

        public DetalhesDoServico(IRepositorioServico repositorioServico, 
            IRepositorioFuncionariosComServicos repositorioFuncionarioComServico, 
            IRepositorioFuncionario repositorioFuncionario)
        {
            _repositorioServico = repositorioServico;
            _repositorioFuncionarioComServico = repositorioFuncionarioComServico;
            _repositorioFuncionario = repositorioFuncionario;
        }

        public FuncionarioEServicoDTO BuscarInformacoesDoServicoSelecionado(int id)
        {
            var servico = _repositorioServico.BuscarPorID(id);
            var idsFuncionario = _repositorioFuncionarioComServico.BuscarIdsDosFuncionariosPeloIdDoServico(id);
            var funcionarios = _repositorioFuncionario.BuscarFuncionariosPorIds(idsFuncionario);

            var servicoDTO = new ServicoDTO(servico);
            var funcionariosDTO = new List<FuncionarioDTO>();
            foreach (var funcionario in funcionarios)
            {
                funcionariosDTO.Add(new FuncionarioDTO(funcionario));
            }

            return new FuncionarioEServicoDTO(funcionariosDTO, servicoDTO);
        }  
    }
}