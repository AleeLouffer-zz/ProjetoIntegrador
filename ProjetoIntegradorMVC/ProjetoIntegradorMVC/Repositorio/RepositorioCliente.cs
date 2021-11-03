using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Repositorio
{
    public class RepositorioCliente : BaseRepositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(Contexto contexto) : base(contexto)
        {
        }

        public Cliente BuscarClientePorCPF(string cpf)
        {
            return _contexto.Set<Cliente>().Where(cliente => cliente.CPF == cpf).SingleOrDefault();
        }
                 
        public void AdicionarClientes(List<Cliente> clientes)
        {
            foreach (var cliente in clientes)
            {
                Adicionar(cliente);
            }
            _contexto.SaveChanges();
        }
        public override List<Cliente> Buscar()
        {
            return _contexto.Clientes
                .Include(cliente => cliente.Agendamentos)
                .AsNoTracking()
                .ToList();
        }
    }
}
