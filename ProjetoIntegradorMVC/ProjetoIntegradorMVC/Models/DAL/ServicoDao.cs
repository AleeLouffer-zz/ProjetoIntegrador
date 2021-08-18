using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Operacoes
{
    public class ServicoDao
    {
        private readonly Contexto _context;
        public List<Servico> BuscarServicosPorId(List<int> servicosId)
        {
            var servicos = new List<Servico>();
            foreach (var id in servicosId)
            {
                var servico = _context.Set<Servico>().First(servico => servico.Id == id);
                servicos.Add(servico);
            }
            return servicos;
        }
    }
}
