using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorioCliente
    {
        Cliente BuscarClientePorCPF(string cpf);
        void AdicionarCliente(List<Cliente> cliente);
        public bool VerificarClienteExistente(Cliente cliente);
    }
}