using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

        public T BuscarPorId(int id) => _contexto.Set<T>().Where(t => t.Id == id).SingleOrDefault();

        public List<T> BuscarTodos() => _contexto.Set<T>().ToList();

        public void Adicionar(T objeto)
        {
            try
            {
                _contexto.Set<T>().Add(objeto);
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException innerException = ex.InnerException as SqlException;

                if (ExisteNoBanco(innerException)) throw new DuplicacaoDeDadosException("Este objeto já existe no banco.");
                throw;
            }
        }

        private static bool ExisteNoBanco(SqlException innerException)
        {
            return innerException.Number == 2627 || innerException.Number == 2601;
        }
    }
}