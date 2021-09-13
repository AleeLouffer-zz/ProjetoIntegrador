using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorio_Funcionario
    {
        List<Funcionario> GetFuncionarios(List<int> id);
        void AddFuncionarios(List<Funcionario> funcionarios);
        public bool VerificarFuncionarioExistente(Funcionario funcionario);
    }
}