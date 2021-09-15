using ProjetoIntegradorMVC.Models.LigaçãoModels;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorio_FuncionarioServico
    {
        void AddFuncionarioComServico(FuncionarioServico funcionariosComServicos);
        void AddFuncionariosComServicos(List<FuncionarioServico> funcionariosComServicos);
        public List<int> ListarIdsFuncionariosPelaIDServico(int idServico);
        public List<FuncionarioServico> VincularFuncionariosComServicos(List<Funcionario> funcionarios, List<Servico> servicos);
    }
}