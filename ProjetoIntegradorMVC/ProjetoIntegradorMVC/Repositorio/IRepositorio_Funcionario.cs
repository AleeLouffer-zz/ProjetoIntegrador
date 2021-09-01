using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorio_Funcionario
    {
        List<Funcionario> GetFuncionario(List<int> id);

        void SaveFuncioarios(List<Funcionario> funcionarios);
    }
}