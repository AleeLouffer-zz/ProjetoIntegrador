using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorioServico
    {
        List<Servico> BuscarServicos();
        Servico BuscarServicoPorId(int id);
        void AdicionarServicos(List<Servico> servicos);
    }
}