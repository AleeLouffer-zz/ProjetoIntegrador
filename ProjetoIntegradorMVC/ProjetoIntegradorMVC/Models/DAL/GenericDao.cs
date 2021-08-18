using ProjetoIntegradorMVC.Models.ContextoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.DAL
{
    public class GenericDao<T> where T: ModeloBase
    {
        private readonly Contexto _context;
        public List<T> BuscarPorId(List<int> ids)
        {
            var modelos = new List<T>();
            foreach (var id in ids)
            {
                var modelo = _context.Set<T>().First(modelo => modelo.Id == id);
                modelos.Add(modelo);
            }
            return modelos;
        }
    }
}
