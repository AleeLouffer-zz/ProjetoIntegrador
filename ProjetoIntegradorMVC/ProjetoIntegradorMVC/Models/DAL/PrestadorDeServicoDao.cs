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
    public class PrestadorDeServicoDao
    {
        private readonly Contexto _context;
        public List<PrestadorDeServico> BuscarPrestadoresDeServicoPorId(List<int> prestadoresDeServico)
        {
            var prestadores = new List<PrestadorDeServico>();
            foreach (var id in prestadoresDeServico)
            {
                var prestadorDeServico = _context.Set<PrestadorDeServico>().First(prestadorDeServico => prestadorDeServico.Id == id);
                prestadores.Add(prestadorDeServico);
            }
            return prestadores;
        }
    }
}
