using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorioFuncionario : IBaseRepositorio<Funcionario>
    {
        bool VerificarFuncionarioExistente(Funcionario funcionario);
        List<Funcionario> BuscarFuncionariosPorIds(List<int> id);
        void AdicionarFuncionarios(List<Funcionario> funcionarios);
    }
}