using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Repositorio
{
    public abstract class BaseRepositorio<T> where T : ClasseBase
    {
        protected readonly Contexto _contexto;

        protected BaseRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        protected T GetPorId(int id)
        {
            return _contexto.Set<T>().Where(t => t.Id == id).SingleOrDefault();
        }

        protected void Adicionar(T objeto)
        {
            _contexto.Set<T>().Add(objeto);
        }

        protected bool VerificarSeExisteNoBanco(T objeto)
        {
            var objetosBanco = _contexto.Set<T>().ToList();
            foreach(var objetoBanco in objetosBanco)
            {
                if(ExisteNoBanco(objetoBanco)) return true;
            }
            return false;
        }

        public abstract bool ExisteNoBanco(T objetoNoBanco);
    }
}