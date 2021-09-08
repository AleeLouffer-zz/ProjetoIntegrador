using ProjetoIntegradorMVC.Models.LigaçãoModels;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorio_FuncionariosComServicos
    {
        void SaveFuncionariosComServicos(FuncionariosComServicos funcionariosComServicos);
        public List<int> ListarFuncionariosID(int idServico);
        void SaveFuncionariosComServicos(List<FuncionariosComServicos> funcionariosComServicos);
    }
}