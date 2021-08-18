using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Operacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Usuarios
{
    public class ClienteDao
    {
        private readonly Contexto _context;
        public List<Cliente> BuscarClientesPorId(List<int> ClientesId)
        {
            var clientes = new List<Cliente>();
            foreach (var id in ClientesId)
            {
                var cliente = _context.Set<Cliente>().First(cliente => cliente.Id == id);
                clientes.Add(cliente);
            }
            return clientes;
        }
    }
}
