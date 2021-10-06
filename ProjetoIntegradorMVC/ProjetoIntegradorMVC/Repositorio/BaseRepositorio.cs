using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Repositorio
{
    public abstract class BaseRepositorio<T> : IBaseRepositorio<T> where T : ClasseBase
    {
        protected readonly Contexto _contexto;

        protected BaseRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public T BuscarPorId(int id)
        {
            return _contexto.Set<T>().Where(t => t.Id == id).SingleOrDefault();
        }

        public List<T> BuscarTodos()
        {
            return _contexto.Set<T>().ToList();
        }

        public void AdicionarUm(T objeto)
        {
            _contexto.Set<T>().Add(objeto);
            _contexto.SaveChanges();
        }
    }
}