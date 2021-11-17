using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Servicos
{
    public class Buscador : IBuscador
    {
        public List<IBuscavel> Buscar(string busca, List<IBuscavel> objetos)
        {
                objetos = objetos.Where(objeto =>
                    NomePareceComBusca(busca, objeto) ||
                    BuscaPareceComNome(busca, objeto)
                ).ToList();

                return objetos;
        }

        public bool BuscaPareceComNome(string busca, IBuscavel objeto)
        {
            return busca.Contains(objeto.ObterNome(), StringComparison.OrdinalIgnoreCase);
        }

        public bool NomePareceComBusca(string busca, IBuscavel objeto)
        {
            return objeto.ObterNome().Contains(busca, StringComparison.OrdinalIgnoreCase);
        }
    }
}
