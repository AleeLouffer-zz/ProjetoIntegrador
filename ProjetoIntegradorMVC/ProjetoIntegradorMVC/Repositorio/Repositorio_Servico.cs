using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Repositorio
{
    public class Repositorio_Servico : IRepositorio_Servico
    {
        private readonly Contexto _contexto;

        public Repositorio_Servico(Contexto contexto)
        {
            _contexto = contexto;
        }

        public List<Servico> GetServicos()
        {
            return _contexto.Set<Servico>().ToList();
        }
        public Servico GetServico(int id)
        {
            return _contexto.Set<Servico>().Where(s => s.Id == id).SingleOrDefault();
        }

        public void SaveServicos(List<Servico> servicos)
        {
            foreach (var servico in servicos)
            {
                _contexto.Set<Servico>().Remove(servico);
            }
            _contexto.SaveChanges();
        }
    }
}
