using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorioFuncionario
    {
        List<Funcionario> BuscarFuncionariosPorIds(List<int> id);
        void Adicionarfuncionarios(List<Funcionario> funcionarios);
        public bool VerificarFuncionarioExistente(Funcionario funcionario);
    }
}