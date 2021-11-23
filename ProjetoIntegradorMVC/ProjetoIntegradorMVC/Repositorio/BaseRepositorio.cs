using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.ContextoDb;
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

        public abstract List<T> ObterTodos();

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

                var excecaoRepresentaDuplicidade = innerException.Number == 2627 || innerException.Number == 2601;

                if (excecaoRepresentaDuplicidade) throw new DuplicacaoDeDadosException("Este objeto já existe no banco.");
                throw;
            }
        }
    }
}