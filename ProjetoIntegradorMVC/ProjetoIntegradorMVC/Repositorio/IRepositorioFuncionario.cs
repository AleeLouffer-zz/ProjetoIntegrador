using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorioFuncionario : IBaseRepositorio<Funcionario>
    {
        List<Funcionario> BuscarFuncionariosPorIds(List<int> id);
        void AdicionarFuncionarios(List<Funcionario> funcionarios);
    }
}