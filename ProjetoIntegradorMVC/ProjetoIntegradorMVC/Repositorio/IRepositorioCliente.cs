using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorioCliente
    {
        Cliente BuscarClientePorCPF(string cpf);
        void AdicionarClientes(List<Cliente> clientes);
    }
}