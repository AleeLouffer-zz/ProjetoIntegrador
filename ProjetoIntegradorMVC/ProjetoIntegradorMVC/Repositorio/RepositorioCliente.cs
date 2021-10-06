using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Repositorio
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly Contexto _contexto;

        public RepositorioCliente(Contexto contexto)
        {
            _contexto = contexto;
        }

        public Cliente BuscarClientePorCPF(string cpf)
        {
            return _contexto.Set<Cliente>().Where(cliente => cliente.CPF == cpf).SingleOrDefault();
        }
                 
        public void AdicionarClientes(List<Cliente> clientes)
        {
            foreach (var cliente in clientes)
            {
                if (cliente.ExisteNoBanco(this)) throw new DuplicateNameException("O cliente já existe.");
                _contexto.Set<Cliente>().Add(cliente);//AdicionarUm base
            }
            _contexto.SaveChanges();
        }
    }
}
