using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorioServico : IBaseRepositorio<Servico>
    {
        void AdicionarServicos(List<Servico> servicos);

        Servico BuscarPorID(int id);
    }
}