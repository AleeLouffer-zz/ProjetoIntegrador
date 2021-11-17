using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Servicos
{
    public interface IBuscador
    {
        bool NomePareceComBusca(string busca, IBuscavel objeto);
        bool BuscaPareceComNome(string busca, IBuscavel objeto);
        List<IBuscavel> Buscar(string busca, List<IBuscavel> objetos);
    }
}