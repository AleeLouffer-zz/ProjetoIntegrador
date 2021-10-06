using ProjetoIntegradorMVC.Models.LigaçãoModels;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorioFuncionariosComServicos
    {
        void AdicionarFuncionariosComServicos(FuncionariosComServicos funcionariosComServicos);
        void AdicionarFuncionariosComServicos(List<FuncionariosComServicos> funcionariosComServicos);
        List<int> BuscarIdsDosFuncionariosPeloIdDoServico(int idServico);
        List<FuncionariosComServicos> VincularFuncionariosComServicos(List<Funcionario> funcionarios, List<Servico> servicos);
    }
}