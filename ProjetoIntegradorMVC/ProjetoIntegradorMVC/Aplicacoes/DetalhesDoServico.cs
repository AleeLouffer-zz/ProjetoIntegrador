using ProjetoIntegradorMVC.DTO;
using ProjetoIntegradorMVC.Repositorio;

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

        public ServicoDTO BuscarInformacoesDoServicoSelecionado(int id)
        {
            var servicoDTO = _repositorioServico.BuscarPorID(id);
            var idsFuncionario = _repositorioFuncionarioComServico.BuscarIdsDosFuncionariosPeloIdDoServico(id);
            var funcionarios = _repositorioFuncionario.BuscarFuncionariosPorIds(idsFuncionario);

            return new ServicoDTO(servicoDTO, funcionarios);
        }  
    }
}