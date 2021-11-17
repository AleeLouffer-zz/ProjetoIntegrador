using ProjetoIntegradorMVC.DTO;
using ProjetoIntegradorMVC.Repositorio;

namespace ProjetoIntegradorMVC.Aplicacoes
{
    public interface IDetalhesDoServico
    {
        FuncionarioEServicoDTO BuscarInformacoesDoServicoSelecionado(int id);
    }
}
