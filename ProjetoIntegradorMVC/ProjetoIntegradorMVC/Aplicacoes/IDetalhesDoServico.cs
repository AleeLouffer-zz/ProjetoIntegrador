using ProjetoIntegradorMVC.DTO;
using ProjetoIntegradorMVC.Repositorio;

namespace ProjetoIntegradorMVC.Aplicacoes
{
    public interface IDetalhesDoServico
    {
        ServicoDTO BuscarInformacoesDoServicoSelecionado(int id);
    }
}
