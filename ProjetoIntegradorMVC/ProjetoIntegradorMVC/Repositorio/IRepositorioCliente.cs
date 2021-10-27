using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorioCliente : IBaseRepositorio<Cliente>
    {
        Cliente BuscarClientePorCPF(string cpf);
        void AdicionarClientes(List<Cliente> clientes);
    }
}