using ProjetoIntegradorMVC.Models.LigaçãoModels;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorio_FuncionariosComServicos
    {
        void AddFuncionarioComServico(FuncionariosComServicos funcionariosComServicos);
        void AddFuncionariosComServicos(List<FuncionariosComServicos> funcionariosComServicos);
        public List<int> ListarIdsFuncionariosPelaIDServico(int idServico);
        public List<FuncionariosComServicos> VincularFuncionariosComServicos(List<Funcionario> funcionarios, List<Servico> servicos);
    }
}