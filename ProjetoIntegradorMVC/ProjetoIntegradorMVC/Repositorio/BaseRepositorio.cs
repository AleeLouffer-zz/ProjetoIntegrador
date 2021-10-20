using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.ContextoDb;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoIntegradorMVC.Repositorio
{
    public abstract class BaseRepositorio<T> : IBaseRepositorio<T> where T : ClasseBase
    {
        protected readonly Contexto _contexto;

        protected BaseRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public T BuscarPorId(int id) => _contexto.Set<T>().Where(t => t.Id == id).SingleOrDefault();

        public List<T> BuscarTodos() => _contexto.Set<T>().ToList();

        public void Adicionar(T objeto)
        {
            _contexto.Set<T>().Add(objeto);
            _contexto.SaveChanges();
        }
    }
}