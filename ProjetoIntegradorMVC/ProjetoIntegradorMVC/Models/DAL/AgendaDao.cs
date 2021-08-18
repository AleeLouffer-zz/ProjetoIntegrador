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
    public class AgendaDao
    {
        private readonly Contexto _context;
        public List<Agenda> BuscarAgendasPorId(List<int> agendasId)
        {
            var agendas = new List<Agenda>();
            foreach (var id in agendasId)
            {
                var agenda = _context.Set<Agenda>().First(agenda => agenda.Id == id);
                agendas.Add(agenda);
            }
            return agendas;
        }
    }
}
